using DefaultNamespace;
using UnityEngine;

public class Mid_Trigger : Angel , IInteracteable
{
    public void Interact(ref int points)
    {
        MidRingTrigger();
    }
}
