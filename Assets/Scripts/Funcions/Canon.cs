using System;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

namespace Funcions
{
    public class Canon : MonoBehaviour , IInteracteable , IAddforce
    {
        bool addforce = false;
        private bool inside = false;
        public float anguloObjetivo = -475.77f;
        [SerializeField]public float velocidad = 2f;
        [SerializeField] public float Force;
        private float time;
        private float initrotation;

        public void Interact(ref int points)
        {
            if (!inside)
            {
                inside = true;
            }
        }
        public void AddForce(ref Rigidbody rigidbody)
        {
            if (addforce)
            {
                rigidbody.AddForce(Vector3.up + Vector3.forward * Force, ForceMode.Impulse);
            }
        }
        public void Awake()
        {
            initrotation = transform.rotation.eulerAngles.z;
        }

        public void Update()
        {
            if (inside)
            {
                //Z(-265.77) -> Z(-475.77)
                Quaternion rotacionDeseada = Quaternion.Euler(0, 90, anguloObjetivo);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotacionDeseada, Time.deltaTime * velocidad);
                time += Time.deltaTime;
                if (time > 2f){
                    addforce = true;
                }

                if (time > 3f)
                {
                    inside = false;
                    time = 0;
                    addforce = false;
                }
            }

            if (!inside)
            {
                Quaternion rotacionDeseada = Quaternion.Euler(0, 90,initrotation);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotacionDeseada, Time.deltaTime * velocidad);
            }
        }
    }
}