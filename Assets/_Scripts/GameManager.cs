using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform playerPaddle;
    public Transform enemyPaddle;
    public BallController ballController;
    public GameObject endGameScreen;
    public TMP_Text winnerText;

    public int playerScore = 0;
    public int enemyScore = 0;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;

    public int pointsToWin = 3;

    private string winnerName = "";
    private bool gameWon = false;

    void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        playerPaddle.transform.position = new Vector3(-7f,0f,0f);
        enemyPaddle.position = new Vector3(7f, 0f, 0f);

        ballController.ResetBall();

        playerScore = 0;
        enemyScore = 0;

        textPointsPlayer.text = playerScore.ToString();
        textPointsEnemy.text = enemyScore.ToString();

        endGameScreen.SetActive(false);
    }

    public void EndGame()
    {
        winnerName = gameWon ? PlayerPrefs.GetString("playerName") : "Inimigo";
        winnerText.text = winnerName + " ganhou!";
        endGameScreen.SetActive(true);

        Invoke(nameof(LoadMenu), 2f);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ScorePlayer()
    {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();
        CheckWin();
    }
    public void ScoreEnemy()
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if (enemyScore >= pointsToWin)
        {
            gameWon = false;
            EndGame();
        }
        else if(playerScore >= pointsToWin)
        {
            gameWon = true;
            int record = PlayerPrefs.GetInt("maxPoints", 0);
            PlayerPrefs.SetInt("maxPoints", (record + 1));
            EndGame();
        }
    }
}
