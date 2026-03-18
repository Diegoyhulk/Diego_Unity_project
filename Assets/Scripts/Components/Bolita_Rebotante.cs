using UnityEngine;

public class Bolita_Rebotante : MonoBehaviour
{
    
    [SerializeField] private GameObject bolitaPrefab;
    private float timer;
    
    [SerializeField] private float time = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LaunchBall();
    }

    private void LaunchBall()
    {
        GameObject copy = Instantiate(bolitaPrefab, transform.position, transform.rotation);
        copy.GetComponent<Rigidbody>().AddForce(Vector3.forward * Random.Range(500f, 5000f));
        //Destroy(copy, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            LaunchBall();
            timer = 0f;
            
        }
    }
}
