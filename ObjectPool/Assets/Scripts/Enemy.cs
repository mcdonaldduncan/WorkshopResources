using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float moveSpeed;

    public Transform target;

    public IObjectPool<Enemy> Pool { get; set; }

    bool hasTarget = true;

    Vector3 velocity;
    Vector3 acceleration;

    private void OnEnable()
    {
        moveSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Steering();
    }

    void Steering()
    {
        var direction = target.position - transform.position;
        var steering = direction.normalized - velocity.normalized;

        velocity += steering;
        transform.position += Time.deltaTime * moveSpeed * velocity;
    }

    void ReturnToPool()
    {
        Pool.Release(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            hasTarget = false;
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            ReturnToPool();
        }
    }

}
