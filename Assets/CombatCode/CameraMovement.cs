using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instance;
    public Room currRoom;
    public Transform target;
    public Camera camera;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame HELLLLOOOOOOO
    void FixedUpdate()
    {
        if (transform.position != target.position) // camera follows player smoothly
        {
            if (currRoom == null)
            {
                return;
            }
            Debug.Log((currRoom.X * currRoom.Width) - (currRoom.Width / 2));
            Debug.Log((currRoom.X * currRoom.Width) + (currRoom.Width / 2));
            Debug.Log((currRoom.Y * currRoom.Height) - (currRoom.Height / 2));
            Debug.Log((currRoom.Y * currRoom.Height) + (currRoom.Height / 2));

            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, (currRoom.X * currRoom.Width) - (currRoom.Width / 2), (currRoom.X * currRoom.Width) + (currRoom.Width / 2));
            targetPosition.y = Mathf.Clamp(targetPosition.y, (currRoom.Y * currRoom.Height) - (currRoom.Height / 2), (currRoom.Y * currRoom.Height) + (currRoom.Height / 2));
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
