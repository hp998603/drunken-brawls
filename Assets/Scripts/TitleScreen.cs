using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private GameObject settings;
    
    public void OnPlayClicked()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenSettings()
    {
        settings.SetActive(true);
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }
}
