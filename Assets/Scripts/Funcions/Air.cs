using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class WindHell : MonoBehaviour , IAddforce
{
    [SerializeField] private float Direction = 1;
    [SerializeField] private float Force;
    public void AddForce(ref Rigidbody rigidbody)
    {
        if (Input.GetMouseButton(1))
        {
            rigidbody.AddForce((Vector3.up * Direction) * (Force * 1.5f), ForceMode.Force);
        }
        else
        {
            rigidbody.AddForce((Vector3.up * Direction) * Force, ForceMode.Force);
        }
    }
}
