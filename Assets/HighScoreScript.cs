using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScoreScript : MonoBehaviour
{

    public static int highscoreValue = 0;
    Text highscore;

    // Start is called before the first frame update
    void Start()
    {
        highscore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        highscore.text = "HighScore: " + highscoreValue;
    }
}
