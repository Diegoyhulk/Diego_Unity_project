using DefaultNamespace;
using UnityEngine;

public class Core_Trigger : Angel , IInteracteable
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
                CoreTrigger();
            }
        }
    }
}
