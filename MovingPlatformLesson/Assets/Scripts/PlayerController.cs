using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveForce;
    [SerializeField] float jumpForce;

    Rigidbody rb;

    bool moveRight;
    bool moveLeft;
    bool moveUp;
    bool onGround;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveLeft = Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.D);
        moveUp = Input.GetKey(KeyCode.W);
    }

    void FixedUpdate()
    {
        if (moveRight)
        {
            rb.AddForce(Vector3.right * moveForce, ForceMode.Impulse);
        }
        if (moveLeft)
        {
            rb.AddForce(Vector3.left * moveForce, ForceMode.Impulse);
        }
        if (moveUp && onGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    
}
