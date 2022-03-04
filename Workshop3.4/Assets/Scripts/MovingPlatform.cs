using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;
    [SerializeField] float speed;

    float step;

    bool shouldMove;
    bool moveToPos1;
    bool moveToPos2;

    void Start()
    {
        shouldMove = false;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, pos1.position) < .5)
        {
            moveToPos2 = true;
            moveToPos1 = false;
        }
        if (Vector3.Distance(transform.position, pos2.position) < .5)
        {
            moveToPos1 = true;
            moveToPos2 = false;
        }
    }

    void FixedUpdate()
    {
        step = speed * Time.deltaTime;

        if (moveToPos1 && shouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos1.position, step);
        }
        if (moveToPos2 && shouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos2.position, step);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shouldMove = true;
            collision.gameObject.transform.SetParent(gameObject.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shouldMove = false;
            collision.gameObject.transform.SetParent(null);
        }
    }

}
