using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyObjectPool : MonoBehaviour
{
    public int maxPoolSize = 50;
    public int stackDefaultCapacity = 10;
    public GameObject enemyPrefab;

    public IObjectPool<Enemy> Pool
    {
        get
        {
            if (_pool == null)
                _pool =
                    new ObjectPool<Enemy>(
                        CreatedPooledItem,
                        OnTakeFromPool,
                        OnReturnedToPool,
                        OnDestroyPoolObject,
                        true,
                        stackDefaultCapacity,
                        maxPoolSize);
            return _pool;
        }
    }

    private IObjectPool<Enemy> _pool;

    private Enemy CreatedPooledItem()
    {
        var go = Instantiate(enemyPrefab);
        Enemy enemy = go.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Pool = Pool;
            return enemy;
        }
        else
        {
            return null;
        }
    }

    private void OnReturnedToPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void OnTakeFromPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);
    }

    private void OnDestroyPoolObject(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }

    internal Enemy TakeFromPool()
    {
        Enemy currentEnemy = Pool.Get();
        return currentEnemy;
    }
}
