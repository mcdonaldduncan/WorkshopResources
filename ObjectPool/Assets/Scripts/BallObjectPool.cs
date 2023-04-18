using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BallObjectPool : MonoBehaviour
{
    public int maxPoolSize = 50;
    public int stackDefaultCapacity = 10;
    public GameObject ballPrefab;

    public IObjectPool<Ball> Pool
    {
        get
        {
            if (_pool == null)
                _pool =
                    new ObjectPool<Ball>(
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

    private IObjectPool<Ball> _pool;

    private Ball CreatedPooledItem()
    {
        var go = Instantiate(ballPrefab);
        Ball ball = go.GetComponent<Ball>();
        if (ball != null)
        {
            ball.Pool = Pool;
            return ball;
        }
        else
        {
            return null;
        }
    }

    private void OnReturnedToPool(Ball ball)
    {
        ball.gameObject.SetActive(false);
    }

    private void OnTakeFromPool(Ball ball)
    {
        ball.gameObject.SetActive(true);
    }

    private void OnDestroyPoolObject(Ball Ball)
    {
        Destroy(Ball.gameObject);
    }

    internal Ball TakeFromPool()
    {
        Ball currentBall = Pool.Get();
        return currentBall;
    }
}
