using UnityEngine;
using UnityEngine.Serialization;

public class Enhanced_Shell : MonoBehaviour
{
    private MeshRenderer[] renderers;
    private bool enabled = true;
    [SerializeField] public float timer;
    private float _Time;

    void Awake()
    {
        renderers = GetComponentsInChildren<MeshRenderer>();
    }

    void Update()
    {
        if (!enabled)
        {
            _Time += Time.deltaTime;
            if (_Time >= timer)
            {
                foreach (MeshRenderer rend in renderers)
                {
                    rend.enabled = true;
                }
                enabled = true;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bolita player) && enabled)
        {foreach (MeshRenderer rend in renderers)
            {
                rend.enabled = false;
            }
            enabled = false;
            _Time = 0;
            player.EnhancedRecharge();
        }
    }
}
