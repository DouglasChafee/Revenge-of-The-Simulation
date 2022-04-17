using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAim : MonoBehaviour
{
    public GameObject enemy;

    void FixedUpdate()
    {
        Vector3 difference = GameObject.Find("player-idle-1").transform.position - transform.position;
        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < -90 || rotationZ > 90)
        {
            if (enemy.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
            }
            else if (enemy.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
            }

        }
    }
}
