using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Level1");
    }

    // Update is called once per frame
    public void OnQuitButtonClicked()
    {
        //Solo funciona durante la ejecución de la build
        Debug.Log("Quit button clicked");
        Application.Quit();
    }
}
