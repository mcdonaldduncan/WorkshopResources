using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Ball : MonoBehaviour
{
    [SerializeField] float despawnDelay;

    Rigidbody _rb;

    public IObjectPool<Ball> Pool { get; set; }

    bool runTimer;
    float lastSpawn;

    float stopTime => lastSpawn + despawnDelay;

    private void OnEnable()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        lastSpawn = Time.time;
        runTimer = true;
    }

    private void OnDisable()
    {
        _rb.velocity = Vector3.zero;
        runTimer = false;
    }

    void ReturnToPool()
    {
        Pool.Release(this);
    }

    private void Update()
    {
        if (transform.position.y < 0)
        {
            ReturnToPool();
        }

        if (!runTimer) return;

        if (Time.time > stopTime)
        {
            ReturnToPool();
        }
    }

    public void Launch(float force, Vector3 direction)
    {
        _rb.AddForce(force * direction, ForceMode.Impulse);
    }
}
