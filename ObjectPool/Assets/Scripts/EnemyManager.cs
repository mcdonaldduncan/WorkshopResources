using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] float _spawnDelay;

    float movementScalar;

    float scaledMoveSpeed => 1 + movementScalar;

    float LastSpawnTime = 0;

    float nextSpawnTime => LastSpawnTime + _spawnDelay;

    EnemyObjectPool _pool;

    // Start is called before the first frame update
    void Start()
    {
        _pool = gameObject.AddComponent<EnemyObjectPool>();
        _pool.enemyPrefab = _enemyPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            movementScalar += .01f;
            _spawnDelay -= .01f;

            LastSpawnTime = Time.time;
            Enemy currentEnemy = _pool.TakeFromPool();
            currentEnemy.target = _target;
            currentEnemy.moveSpeed *= scaledMoveSpeed;

            float x = Random.Range(0f, 15f);
            float z = Random.Range(10f, 15f);

            if (Random.Range(0, 2) == 0)
            {
                x *= -1;
            }
            if (Random.Range(0, 2) == 0)
            {
                z *= -1;
            }

            currentEnemy.transform.position = new Vector3(x, 1, z);
        }

    }
}
