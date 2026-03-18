using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [field: SerializeField] public TMP_Text ScoreText { get; private set; }
    [field: SerializeField] public TMP_Text HP_Text{ get; private set; }

    public static UiManager Instance { get; private set; } //Una variable estatica pertenece a la
                                                           //clase, no a las variables

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("Level1");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
