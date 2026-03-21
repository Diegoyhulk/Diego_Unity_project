using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    public void OnReplayButtonClicked()
    {
        SceneManager.LoadScene("Level1");
    }
    public void OnMenuButtonClicked()
    {
        //Solo funciona durante la ejecución de la build
        SceneManager.LoadScene("Menu");
    }
}
