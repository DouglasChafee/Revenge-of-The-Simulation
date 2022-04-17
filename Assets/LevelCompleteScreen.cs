using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteScreen : MonoBehaviour
{
    public Text itemText;
    [SerializeField] private string newLevel;

    public void Setup(string item)
    {
        gameObject.SetActive(true);
        itemText.text = item;
    }

    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            gameObject.SetActive(false);
            PlayerCombat.killedBoss = false;
            SceneManager.LoadScene(newLevel);
        }
    }
}
