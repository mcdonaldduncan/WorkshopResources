using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float maxSpeed;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Follow();
       
    }

    void Follow()
    {
        Vector2 desired = target.position - transform.position;
        //desired /= desired.magnitude;
        //desired *= maxSpeed;
        desired = Vector2.ClampMagnitude(desired, maxSpeed);
        //float x = Mathf.Clamp(desired.x, -maxSpeed, maxSpeed);
        //float y = Mathf.Clamp(desired.y, -maxSpeed, maxSpeed);
        //Vector2 clampedDesired = new Vector2(x, y);
        Vector2 steer = desired - (Vector2)rb.velocity;
        rb.AddForce(steer, ForceMode.Acceleration);
       
    }
}
