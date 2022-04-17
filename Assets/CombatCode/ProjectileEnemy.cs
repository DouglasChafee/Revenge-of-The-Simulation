using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed = 100f;
    public float retreatDistance = 5;

    private bool facingRight = true;

    public float shotDelay;
    private float timeToShot;

    public GameObject projectile;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("player-idle-1").transform;
        timeToShot = shotDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, target.position) < retreatDistance)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
            facingRight = false;
        }

        if(timeToShot <= 0)
        {
            Instantiate(projectile, rb.transform.position, Quaternion.identity);
            timeToShot = shotDelay;
        }
        else
        {
            timeToShot -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Vector3 difference = target.position - transform.position;
        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < -90 || rotationZ > 90)
        {
            if (rb.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
            }
            else if (rb.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
            }

        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
