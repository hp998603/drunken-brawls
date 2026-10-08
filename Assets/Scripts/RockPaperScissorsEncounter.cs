using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class RockPaperScissorsEncounter : MonoBehaviour
{
    public enum Choice
    {
        Rock,
        Paper,
        Scissors
    }

    [SerializeField] private GameObject choicePanel;
    [SerializeField] private WorldMovement worldMovement;
    [SerializeField] private LivesManager livesManager;
    [SerializeField] private AudioSource damageSound;
    [SerializeField] private AudioSource winSound;
    [SerializeField] private Image Hands;
    [SerializeField] private Sprite Rock;
    [SerializeField] private Sprite Scissors;
    [SerializeField] private Sprite Paper;

    private Choice enemyChoice;

    // the enemy currently fighting the player
    private GameObject currentEnemy;

    void Start()
    {
        choicePanel.SetActive(false);
    }

    public void StartEncounter(GameObject enemy)
    {
        currentEnemy = enemy;
        
        // randomly select 0/1/2 for rock/paper/scissors
        enemyChoice = (Choice)Random.Range(0, 3);

        Debug.Log("Enemy chose: " + enemyChoice);

        choicePanel.SetActive(true);
    }

    // called by UI buttons 
    public void ChooseRock()
    {
        CheckResult(Choice.Rock);
        Hands.sprite = Rock;
    }

    public void ChoosePaper()
    {
        CheckResult(Choice.Paper);
        Hands.sprite = Paper;
    }

    public void ChooseScissors()
    {
        CheckResult(Choice.Scissors);
        Hands.sprite = Scissors;
    }

    // rock paper scissors logic
    void CheckResult(Choice playerChoice)
    {
        choicePanel.SetActive(false);

        Debug.Log("Player chose: " + playerChoice);
        Debug.Log("Enemy chose: " + enemyChoice);

        if (playerChoice == enemyChoice)
        {
            Debug.Log("DRAW");

            StartEncounter(currentEnemy);
            return;
        }

        bool playerWon =
            (playerChoice == Choice.Rock && enemyChoice == Choice.Scissors) ||
            (playerChoice == Choice.Paper && enemyChoice == Choice.Rock) ||
            (playerChoice == Choice.Scissors && enemyChoice == Choice.Paper);

        if (playerWon)
        {
            PlayerWins();
        }
        else
        {
            PlayerLoses();
        }
    }

    void PlayerWins()
    {
        Debug.Log("YOU WIN!");

        winSound.Play();
        worldMovement.StartWorld();

        // reset this so the next enemy can move
        Enemy.hasReachedCamera = false;

        Destroy(currentEnemy);
    }

    void PlayerLoses()
    {
        Debug.Log("YOU LOST!");

        damageSound.Play();
        livesManager.LoseLife();
        worldMovement.StartWorld();

        // reset this so the next enemy can move
        Enemy.hasReachedCamera = false;

        Destroy(currentEnemy);
    }
}