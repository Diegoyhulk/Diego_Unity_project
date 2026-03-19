using System;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public class Angel : MonoBehaviour, IAddforce
{
    GameObject OuterSide;
    GameObject MidSide;
    GameObject InnerSide;
    public bool pushbackTrigger;

    private void Awake()
    {
        OuterSide = GameObject.Find("OuterSide");
        MidSide = GameObject.Find("MidSide");
        InnerSide = GameObject.Find("InnerSide");
    }

    public void OuterRingTrigger()
    {
        OuterSide.SetActive(false);
    }
    public void MidRingTrigger()
    {
        MidSide.SetActive(false);
        pushbackTrigger = true;
    }
    public void InnerRingTrigger()
    {
        InnerSide.SetActive(false);
        pushbackTrigger = true;
    }
    public void CoreTrigger()
    {
        Destroy(this.gameObject);
        pushbackTrigger = true;
    }

    public void Activate()
    {
        pushbackTrigger = true;
    }
    public void IsOutP()
    {
        Debug.Log("IsOutP");
        pushbackTrigger = false;
    }

    public void AddForce(ref Rigidbody rigidbody)
    {
        if (pushbackTrigger)
        {
            rigidbody.AddForce(transform.up * 1000, ForceMode.Force);
        }
    }
}
