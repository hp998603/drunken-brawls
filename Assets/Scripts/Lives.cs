using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    // image array to hold each heart
    [SerializeField] private Image[] hearts;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Sprite brokenHeart;

    private int lives = 3;

    public void LoseLife()
    {
        // decrement lives
        lives--;

        if (lives == 2)
        {
            heart3.sprite = brokenHeart;
        }
        else if (lives == 1)
        {
            heart2.sprite = brokenHeart;
        }
        else
        {
            heart1.sprite = brokenHeart;
        }

        Debug.Log("Lives remaining: " + lives);

        //UpdateHearts();

        if (lives <= 0)
        {
            PlayerDied();
        }
    }

    // void UpdateHearts()
    // {
    //     // control the visibility of each heart
    //     for (int i = 0; i < hearts.Length; i++)
    //     {
    //         if (i < lives)
    //         {
    //             hearts[i].gameObject.SetActive(true);
    //         }
    //         else
    //         {
    //             hearts[i].gameObject.SetActive(false);
    //         }
    //     }
    // }

    void PlayerDied()
    {
        Debug.Log("YOU DIED!");

        SceneManager.LoadScene("YouDied");
    }
}