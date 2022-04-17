using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
	public int health = 500;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 700)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			GetComponent<Animator>().SetTrigger("Death");
		}
	}

	public void Die()
	{
        PlayerCombat.killedBoss = true;
		Destroy(gameObject);
	}
}
