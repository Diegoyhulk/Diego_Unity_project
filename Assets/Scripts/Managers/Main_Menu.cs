using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Level1");
    }
    public void OnQuitButtonClicked()
    {
        //Solo funciona durante la ejecución de la build
        Debug.Log("Quit button clicked");
        Application.Quit();
    }
}
