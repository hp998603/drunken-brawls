using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    public void OnPlayClicked()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnSettingsClicked()
    {
        
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }
}
