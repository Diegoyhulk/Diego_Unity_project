using DefaultNamespace;
using NUnit.Framework;
using UnityEngine;

public class Outer_Trigger : Angel, IInteracteable, IOut
{
    private bool IsIn = false;
    public void Interact(ref int points)
    {
        IsIn = true;
    }

    void Update()
    {
        if (IsIn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Activate();
                OuterRingTrigger();
            }
        }
    }
    public void IsOut()
    {
        IsIn = false;
    }
}
