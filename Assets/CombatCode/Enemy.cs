using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    GameObject findplayer;

    public HealthbarBehaviour Healthbar;

    float nextAttackTime = 0f;
    public int damage = 25;

    void Awake()
    {
        findplayer = GameObject.FindGameObjectWithTag("Player");
    }


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Healthbar.SetHealth(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Healthbar.SetHealth(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            ScoreScript.scoreValue += 1;
            findplayer.GetComponent<PlayerCombat>().GainHealth(5);
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Attack(hitInfo);
    }

    void OnTriggerStay2D(Collider2D hitInfo)
    {
        Attack(hitInfo);
    }

    private void Attack(Collider2D hitInfo)
    {
        if (Time.time >= nextAttackTime)
        {
            PlayerCombat player = hitInfo.GetComponent<PlayerCombat>();
            if (player != null)
            {
                player.TakeDamage(damage);
                nextAttackTime = Time.time + 0.5f;
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
