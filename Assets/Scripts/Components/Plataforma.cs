using UnityEngine;
using UnityEngine.Serialization;

public class Plataforma : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] public int speed;
    private float timer;
    private float downtime;
    private bool Player_on = false;
    private bool Top = false;
    private bool Bottom = true;
    [SerializeField] private float rotation;
    [SerializeField] private Vector3 Direction = Vector3.zero;
    [SerializeField] private Vector3 Rotation = Vector3.zero;

    [SerializeField] private float time = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_on && !Top)
        {
            Go_Up();
            UpdateDirection();
            UpdateRotation(); 
        }
        else if (!Player_on && !Bottom)
        {
            Go_Down();
            UpdateDirection();
            UpdateRotation(); 
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Bolita player))
        {
            Player_on = true;
            Top = false;
            Bottom = true;
            Direction *= -1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Bolita player))
        {
            Player_on = false;
            Top = true;
            Bottom = false;
            Direction *= -1;
        }
    }
    private void UpdateDirection()
    {
        rb.linearVelocity = (Direction.normalized * speed);
    }
    private void UpdateRotation()
    {
        this.gameObject.transform.Rotate(Rotation  * (rotation * Time.deltaTime),
            Space.World);
    }

    private void Go_Up()
    {
        downtime += Time.deltaTime;
        timer += Time.deltaTime;
        if (timer >= time)
        {
            Top = true;
            Bottom = false;
        }
    }
    private void Go_Down()
    {
        timer -= Time.deltaTime;
        downtime -= Time.deltaTime;
        if (downtime <= 0)
        {
            Top = false;
            Bottom = true;
        }
    }
}