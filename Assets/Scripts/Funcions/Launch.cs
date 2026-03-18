using DefaultNamespace;
using UnityEngine;

public class Launch : MonoBehaviour , IAddforce
{
    [SerializeField] private Vector3 Direction;
    [SerializeField] private float Force;
    private bool jumps = true;
    public void AddForce(ref Rigidbody rigidbody)
    {
        if (jumps)
        {
            rigidbody.AddForce(Direction * Force, ForceMode.Impulse);
            jumps = false;
        }
    }
}
