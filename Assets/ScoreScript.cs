using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{

    public static int scoreValue = 0;
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        score = GetComponent<Text>();
        //scoreValue = PlayerPrefs.GetInt("Score");
        score.text = "Score: " + scoreValue;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;
        //PlayerPrefs.SetInt("Score", scoreValue);
    }
}
