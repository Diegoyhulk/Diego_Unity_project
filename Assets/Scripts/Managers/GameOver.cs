using UnityEngine;
using UnityEngine.SceneManagement;

public class GmeOver : MonoBehaviour
{
    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene("Level1");
    }

    // Update is called once per frame
    public void OnMenuButtonClicked()
    {
        SceneManager.LoadScene("Menu");
    }
}
