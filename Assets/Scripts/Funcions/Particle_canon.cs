using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.Cinemachine;
using UnityEngine;

namespace Funcions
{
    public class Particle_canon : MonoBehaviour , IInteracteable
    {
        [SerializeField] private ParticleSystem Boom;
        private bool play;
        private float timer;
        public void Interact(ref int points)
        {
            play = true;
        }

        void Update()
        {
            if (play)
            {
                if(timer == 0)
                {
                    Boom.Play();
                }
                timer += Time.deltaTime;
                if (timer > 1)
                {
                    Boom.Stop();
                    timer = 0;
                    play = false;
                }
            }
        }
        
    }
}