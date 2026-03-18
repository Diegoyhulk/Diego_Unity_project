using DefaultNamespace;
using UnityEngine;

public class WindHell : MonoBehaviour , IAddforce
{
    [SerializeField] private float Direction = 1;
    [SerializeField] private float Force;
    public void AddForce(ref Rigidbody rigidbody)
    {
        rigidbody.AddForce((Vector3.up * Direction) * Force, ForceMode.Force);
    }
}
