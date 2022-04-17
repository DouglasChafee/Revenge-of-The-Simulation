using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public Transform player;

    public bool facingRight = true;

    public void LookAtPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (player.position.x > transform.position.x && facingRight == false)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            facingRight = true;
        }
        else if (player.position.x < transform.position.x && facingRight == true)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            facingRight = false;
        }
    }
}
