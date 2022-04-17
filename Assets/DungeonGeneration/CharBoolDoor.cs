using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharBoolDoor : MonoBehaviour
{

    public bool wentThrough = false;
    public int floor = 1;
    public bool TripleShot = false;

    public Vector3 leftChange;
    public Vector3 rightChange;
    public Vector3 topChange;
    public Vector3 bottomChange;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LeftDoor"))
        {
            if (wentThrough == false)
            {
                wentThrough = true;
                transform.position += leftChange;
                StartCoroutine(Timedelay(other));
            }
        }

        if (other.CompareTag("RightDoor"))
        {
            if (wentThrough == false)
            {
                wentThrough = true;
                transform.position += rightChange;
                StartCoroutine(Timedelay(other));
            }
        }

        if (other.CompareTag("TopDoor"))
        {
            if (wentThrough == false)
            {
                wentThrough = true;
                transform.position += topChange;
                StartCoroutine(Timedelay(other));
            }
        }

        if (other.CompareTag("BottomDoor"))
        {
            if (wentThrough == false)
            {
                wentThrough = true;
                transform.position += bottomChange;
                StartCoroutine(Timedelay(other));
            }
        }

        if (other.CompareTag("FloorSwitch"))
        {
            TripleShot = true;
        }
    }

    IEnumerator Timedelay(Collider2D other)
    {
        yield return new WaitForSeconds(0.2f);
        wentThrough = false;
    }
}
