using UnityEngine;
using UnityEngine.SceneManagement;

public class World_Changer : MonoBehaviour
{
    [SerializeField] private string Level;
    float timer = 0;
    private bool ended = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Bolita Player))
        {
            if (Player.points >= 21)
            {
                  ended = true;  
            }

            if (Player.points < 21)
            {
                Player.gameObject.transform.position = Player.initposition;
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ended)
        {
            timer += Time.deltaTime;
            if (timer > 2f) {SceneManager.LoadScene(Level);}
            enabled = false;
        }
    }
}
