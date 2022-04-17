using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerCombat player = hitInfo.GetComponent<PlayerCombat>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
