using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;
    [SerializeField] float speed;
    [SerializeField] float delayTime;

    WaitForSeconds delay;

    float step;

    bool shouldMove;
    bool moveToPos1;
    bool moveToPos2;
    bool canTrigger;
    bool onDelay;

    void Start()
    {
        shouldMove = false;
        delay = new WaitForSeconds(delayTime);
    }

    void Update()
    {
        CheckPosition();
        CheckStart();
    }

    IEnumerator ResetDelay()
    {
        yield return delay;
        onDelay = false;
    }

    void CheckStart()
    {
        if (!canTrigger)
            return;
        if (onDelay)
            return;

        if (Input.GetKey(KeyCode.E))
        {
            shouldMove = !shouldMove;
            onDelay = true;
            StartCoroutine(ResetDelay());
        }
    }

    void CheckPosition()
    {
        if (!shouldMove)
            return;

        if (Vector3.Distance(transform.position, pos1.position) < 1)
        {
            moveToPos2 = true;
            moveToPos1 = false;
        }
        if (Vector3.Distance(transform.position, pos2.position) < 1)
        {
            moveToPos1 = true;
            moveToPos2 = false;
        }
    }

    private void FixedUpdate()
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
            collision.transform.SetParent(transform);
            canTrigger = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            canTrigger = false;
        }
    }
}
