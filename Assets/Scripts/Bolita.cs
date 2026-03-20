using System;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class Bolita : MonoBehaviour
{
    //rb.AddForce(Vector3.up * 10, ForceMode.Force)
    private Rigidbody rb;
    private SphereCollider sphere;
    private Vector3 movement;
    public Vector3 initposition;
    private AudioSource audiosource;
    public float timer;
    private float dmg_time;
    private float healtime;
    private int HP = 10;
    [Header("Movement")] [SerializeField] private float Jumpspeed;
    [SerializeField] private float SuperJumpspeed;
    public float MovmentF = 100;
    public int points;
    public int jumps;
    private bool jumpif = true;
    private bool Checkpoint1 = false;
    private bool Checkpoint2 = false;
    private int Superjump;

    [Header("Chekers")] [SerializeField] private LayerMask whatisinteractable;

    [Header("SFX")] [SerializeField] private AudioClip JumpSound;
    [SerializeField] private AudioClip RechargeSound;

    public void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
        sphere = GetComponent<SphereCollider>();
        initposition = gameObject.transform.position;
    }

    void Start()
    {
        UiManager.Instance.ScoreText.text = "Score: " + points;
        UiManager.Instance.HP_Text.text = "HP: " + HP;
    }

    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal"); //Solo puede devolver -1, 0 ,1 con las teclas A y D y las flachas <- y ->
        float vInput = Input.GetAxisRaw("Vertical"); //Lo mismo pero con las teclas verticales
        movement = new Vector3(hInput, 0, vInput).normalized;
        Jump();
        SuperJump();
        Interact1();
        Crouch();
        if (!sphere.enabled)
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                sphere.enabled = true;
                timer = 0f;
                HP = 3;
            }
        }
    }

    private void FixedUpdate() //Cada 0,02 segundos se actualiza cada vez
    {
        rb.AddForce(movement * MovmentF, ForceMode.Force);
    }

    public void Jump()
    {
        if(Superjump > 0){return;}
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        if (jumps > 0)
        {
            Audio_Music.Instance.PlaySfx(JumpSound);
            rb.AddForce(Vector3.up * Jumpspeed, ForceMode.Impulse);
            jumps--;
            if (jumps < 2)
            {
                jumpif = true;
            }
        }
        audiosource.clip = JumpSound;
        audiosource.volume = 0f;
        audiosource.Play();

    }

    private void SuperJump()
    {
        if (Superjump <= 0) { return;}
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        if (jumps > 0)
        {
            Audio_Music.Instance.PlaySfx(JumpSound);
            rb.AddForce(Vector3.up * SuperJumpspeed, ForceMode.Impulse);
            jumps--;
            if (jumps < 2)
            {
                jumpif = true;
            }
        }
        audiosource.clip = JumpSound;
        audiosource.volume = 0f;
        audiosource.Play();
        Superjump--;
    }

    private void Crouch()
    {
        if (Input.GetMouseButton(0))
        {
            rb.AddForce(Vector3.down * 3, ForceMode.Force);
            MovmentF = 20f;
        }
        if (Input.GetMouseButtonUp(0))
        {
            MovmentF = 100f;
        }
    }

    private void Interact1()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;
        if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit,
                transform.localScale.z + 0.05f, whatisinteractable))
        {
            Destroy(hit.collider.gameObject);
        }
    }

    public void Recharge()
    {
        audiosource.clip = RechargeSound;
        audiosource.volume = 0.3f;
        audiosource.Play();
        jumps = 2;
        jumpif = false;
    }

    public void EnhancedRecharge()
    {
        audiosource.clip = RechargeSound;
        audiosource.volume = 0.3f;
        audiosource.Play();
        jumps = 2;
        jumpif = false;
        Superjump += 2;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IInteracteable interacteable))
        {
            interacteable.Interact(ref points);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Heal"))
        {
            healtime += Time.deltaTime;
            if (healtime >= 2f && HP < 3)
            {
                sphere.enabled = true;
                healtime = 0f;
                dmg_time = 0;
                HP++;
                UiManager.Instance.HP_Text.text = "HP: " + HP;
                Recharge();
            } 
        }

        if (other.gameObject.TryGetComponent(out IAddforce addforce))
        {
            addforce.AddForce(ref rb);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IOut iout))
        {
            iout.IsOut();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("? Block"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Heal"))
        {
            healtime = 0;
        }
        if (other.gameObject.CompareTag("Suelo") && jumpif)
        {
            Recharge();
        }
        if (other.gameObject.CompareTag("DMG"))
        {
            --HP;
            UiManager.Instance.HP_Text.text = "HP: " + HP;
            if (HP == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        if (other.gameObject.CompareTag("Door") && points > 20)
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            Debug.Log("Door");
        }

        if (other.gameObject.CompareTag("Out"))
        {
            SceneManager.LoadScene("GameOver");
        }
        
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Lava"))
        {
            dmg_time += Time.deltaTime;
            if (dmg_time >= 3f)
            {
                HP -= 2;
                dmg_time = 0f;
                UiManager.Instance.HP_Text.text = "HP: " + HP;
            }  
        }
    }
    
    private void OnDrawGizmos() //Dibujar en el editor
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down);
    }
}
