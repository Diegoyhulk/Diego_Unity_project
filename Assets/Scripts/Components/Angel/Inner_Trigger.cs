using DefaultNamespace;
using UnityEngine;

public class Inner_Trigger : Angel , IInteracteable
{
    public void Interact(ref int points)
    {
        InnerRingTrigger();
    }
}
