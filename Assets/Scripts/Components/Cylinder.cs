using UnityEngine;
using UnityEngine.SocialPlatforms;

public class cYLINDER : MonoBehaviour
{
    [SerializeField] public Vector3 torque = new Vector3(0f, 0f, 0f);
    [SerializeField] public float rforce;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(transform.TransformDirection(torque * rforce), ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
