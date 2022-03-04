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
    bool jump;
    bool onGround;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveLeft = Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.D);
        jump = Input.GetKey(KeyCode.Space);
    }

    void FixedUpdate()
    {
        if (moveLeft)
        {
            rb.AddForce(Vector3.left * moveForce, ForceMode.Impulse);
        }
        if (moveRight)
        {
            rb.AddForce(Vector3.right * moveForce, ForceMode.Impulse);
        }
        if (jump && onGround)
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
