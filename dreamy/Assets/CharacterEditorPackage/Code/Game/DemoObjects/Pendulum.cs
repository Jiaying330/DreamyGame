using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed;
    public float leftAngle;
    public float rightAngle;
    public GameObject target;

    bool movingClockwise;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movingClockwise = true;

    }

    void Update()
    {
        Move();
    }

    public void ChangeMoveDir()
    {
        if(transform.rotation.z > rightAngle)
        {
            movingClockwise = false;
        }
        if(transform.rotation.z < leftAngle)
        {
            movingClockwise = true;
        }
    }

    public void Move()
    {
        ChangeMoveDir();
        if(movingClockwise)
        {
            rb.transform.RotateAround(target.transform.position, Vector3.forward, moveSpeed);
            // rb.angularVelocity = moveSpeed;
        }
        else
        {
            rb.transform.RotateAround(target.transform.position, Vector3.forward, -moveSpeed);
        }
    }

}
