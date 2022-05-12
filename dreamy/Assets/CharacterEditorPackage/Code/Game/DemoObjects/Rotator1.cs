using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator1 : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed;
    public float leftAngle;
    public float rightAngle;

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
            // rightAngle = Random.Range(0.1f, 0.8f);
            // Debug.Log("movingClockwise = " + movingClockwise);
        }
        if(transform.rotation.z < leftAngle)
        {
            movingClockwise = true;
            // leftAngle = Random.Range(-0.1f, -0.8f);
            // Debug.Log("movingClockwise = " + movingClockwise);
            // Debug.Log(rightAngle);
        }
    }

    public void Move()
    {
        ChangeMoveDir();
        // Debug.Log("transform.rotation.z = " + transform.rotation.z );
        if(movingClockwise)
        {
            rb.transform.Rotate(Vector3.up, Time.fixedDeltaTime * moveSpeed);
            // rb.angularVelocity = moveSpeed;
        }
        else
        {
            rb.transform.Rotate(Vector3.up, Time.fixedDeltaTime * -moveSpeed);
        }
    }
}
