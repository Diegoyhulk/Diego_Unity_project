using System;
using DefaultNamespace;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

namespace Funcions
{
    public class Canon : MonoBehaviour , IInteracteable , IAddforce
    {
        bool addforce = false;
        private bool inside = false;
        private float anguloObjetivo = -475.77f;
        [SerializeField] private float velocidad = 2f;
        [SerializeField] private float Force;
        [SerializeField] private CinemachineCamera playercamera;
        private float time;
        private float initrotation;

        public void Interact(ref int points)
        {
            if (!inside && points > 20) 
            {
                inside = true;
                playercamera.enabled = false;
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
                if (time > 3f){
                    addforce = true;
                    playercamera.enabled = true;
                }
                if (time > 4f)
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