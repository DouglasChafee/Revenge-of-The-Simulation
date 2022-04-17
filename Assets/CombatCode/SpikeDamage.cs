using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    float nextAttackTime = 0f;
    public int damage = 25;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Spike Triggered!");
            Attack(other);

        }

        void Attack(Collider2D hitInfo)
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

    }
}
