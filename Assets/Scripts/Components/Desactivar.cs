using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivar : MonoBehaviour
{
    private MeshRenderer mesh;
    private BoxCollider col;
    //[SerializeField] private float timer;
    //[SerializeField] private float time = 1.5f;
   // bool active = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Switchstate();
    }

    private void Awake()
    {
        mesh = this.gameObject.GetComponent<MeshRenderer>();
        col = this.gameObject.GetComponent<BoxCollider>();

       // StartCoroutine(Semaforo());
    }

    private void Change()
    {
       // if (!active)
       // {
       //     StartCoroutine(Semaforo());
       // }
        mesh.enabled = !mesh.enabled;
        col.enabled = !col.enabled;
    }

    void Update()
    {
        // timer += Time.deltaTime;
        // if (timer >= time)
        // {
        //     Change();
        //     timer = 0f;
        // }
    }

    private IEnumerable Switchstate()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            mesh.enabled = !mesh.enabled;
            col.enabled = !col.enabled;
        }
    }

   // private IEnumerator Semaforo()
   // {
   //     while (true)
   //     {
   //        // active = true;
   //         Debug.Log("Verde");
   //         yield return new WaitForSeconds(2f);
   //         Debug.Log("Amarillo");
   //         yield return new WaitForSeconds(1.5f);
   //         Debug.Log("Rojo");
   //        // active = false;
   //     }
   // }
}
