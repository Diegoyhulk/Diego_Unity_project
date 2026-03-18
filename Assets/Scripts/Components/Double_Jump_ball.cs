using UnityEngine;
using UnityEngine.Serialization;

public class Double_Jump_ball : MonoBehaviour
{
    private bool enabled = true;
    [SerializeField] public float timer;
    public float _Time;
    private MeshRenderer _meshRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!enabled)
        {
            _Time += Time.deltaTime;
            if (_Time >= timer)
            {
                _meshRenderer.enabled = true;
                enabled = true;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bolita player) && enabled)
        {
            _meshRenderer.enabled = false;
            enabled = false;
            _Time = 0;
            player.Recharge();
        }
    }
}
