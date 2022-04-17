using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public Text highscoreText;

    public void Setup(int score, int highscore)
    {
        gameObject.SetActive(true);
        pointsText.text = "Score: " + score.ToString();
        highscoreText.text = "HighScore: " + highscore.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("GrasslandMain");
        PlayerPrefs.SetInt("Score", 0);
        ScoreScript.scoreValue = 0;
    }
}
