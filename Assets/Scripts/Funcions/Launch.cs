using DefaultNamespace;
using UnityEngine;

public class Launch : MonoBehaviour , IAddforce, IInteracteable
{
    [SerializeField] private Vector3 Direction;
    [SerializeField] private float Force;
    private bool launch = false;
    public void AddForce(ref Rigidbody rigidbody)
    {
        if(launch)
            rigidbody.AddForce(Direction * Force, ForceMode.Impulse); launch = false;
    }

    public void Interact(ref int points)
    {
        if (points > 34)
        {
            launch = true;
        }
    }
}
