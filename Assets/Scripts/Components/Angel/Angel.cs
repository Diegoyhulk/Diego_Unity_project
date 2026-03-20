using System;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public class Angel : MonoBehaviour, IAddforce
{
    GameObject OuterSide;
    GameObject MidSide;
    GameObject InnerSide;
    GameObject Core;
    GameObject MidShells;
    GameObject InnerShells;
    GameObject CoreShells;
    private bool pushbackTrigger;
    private bool finalhit;
    private bool Disable_Outer;
    private bool Disable_Mid;
    private bool Disable_Inner;
    private bool Disable_Core;
    private bool awake = true;

    private void Awake()
    {
        OuterSide = GameObject.Find("OuterSide");
        MidSide = GameObject.Find("MidSide");
        InnerSide = GameObject.Find("InnerSide");
        Core = GameObject.Find("Nucli");
        MidShells = GameObject.Find("MidShells");
        InnerShells = GameObject.Find("InnerShells");
        CoreShells = GameObject.Find("CoreShells");
    }

    public void OuterRingTrigger()
    {
        pushbackTrigger = true;
        Disable_Outer = true;
    }
    public void MidRingTrigger()
    {
        pushbackTrigger = true;
        Disable_Mid = true;
    }
    public void InnerRingTrigger()
    {
        pushbackTrigger = true;
        Disable_Inner = true;
    }
    public void CoreTrigger()
    {
        finalhit = true;
        Disable_Core = true;
    }
    public void IsOutP()
    {
        Debug.Log("IsOutP");
        pushbackTrigger = false;
    }

    void FixedUpdate()
    {
        if (awake)
        {
            MidShells.SetActive(false);
            InnerShells.SetActive(false);
            CoreShells.SetActive(false);
            awake = false;
        }
    }

    public void AddForce(ref Rigidbody rigidbody)
    {
        if (pushbackTrigger)
        {
            Debug.Log("AddForce");
            rigidbody.AddForce(new Vector3(0f,0f,-1f) * 200, ForceMode.Impulse);
        }

        if (finalhit)
        {
            rigidbody.AddForce(transform.up * 200, ForceMode.Impulse);
        }
        if (Disable_Outer)
        {
            OuterSide.SetActive(false);
            MidShells.SetActive(true);
            Disable_Outer = false;
        }

        if (Disable_Mid)
        {
            MidSide.SetActive(false);
            MidShells.SetActive(false);
            InnerShells.SetActive(true);
            Disable_Mid = false;
        }

        if (Disable_Inner)
        {
            InnerSide.SetActive(false);
            InnerShells.SetActive(false);
            CoreShells.SetActive(true);
            Disable_Inner = false;
        }

        if (Disable_Core)
        {
            Core.SetActive(false);
            CoreShells.SetActive(false);
            Disable_Core = false;
        }
    }
}
