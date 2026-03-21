using UnityEngine;

public class Audio_Music : MonoBehaviour
{
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioSource currentMusicSource;
    public static Audio_Music Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlaySfx(AudioClip clip)
    {
        audiosource.PlayOneShot(clip, 0.2f);
    }
    void Update()
    {
        
    }
}
