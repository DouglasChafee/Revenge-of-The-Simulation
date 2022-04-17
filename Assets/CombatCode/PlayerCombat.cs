using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public static bool killedBoss = false;

    public GameOverScreen GameOverScreen;

    public HealthBar healthBar;

    public CharBoolDoor getPlayerBool;

    public List<int> scores = new List<int>();

    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool tripleShot = false;
    
    float nextAttackTime = 0f;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
                nextAttackTime = Time.time + 0.33f;
            }

            if (Input.GetMouseButtonDown(1) && tripleShot)
            {
                TripleShot();
                nextAttackTime = Time.time + 0.66f;


            }

        }

    }

    void Shoot()
    {
        FindObjectOfType<AudioManager>().Play("Shoot");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void TripleShot()
    {
        Shoot();
        Invoke("Shoot", 0.15f);
        Invoke("Shoot", 0.3f);
    }

        public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void GainHealth(int health)
    {
        if (currentHealth < 100)
        {
            currentHealth += health;
            FindObjectOfType<AudioManager>().Play("HealthGain");
        }
        healthBar.SetHealth(currentHealth);
    }

    void Die()
    {
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        Destroy(gameObject);
        if (ScoreScript.scoreValue > HighScoreScript.highscoreValue)
        {
            HighScoreScript.highscoreValue = ScoreScript.scoreValue;
        }
        GameOverScreen.Setup(ScoreScript.scoreValue, HighScoreScript.highscoreValue);  // add a new text in gameover and add that text to background unity square, and add this value to a list and check for largest in list using temp for highscore which is another text, create a new function to hold highscore same as this one which holds score
        
        //SceneManager.LoadScene("GrasslandMain");
    }
}
