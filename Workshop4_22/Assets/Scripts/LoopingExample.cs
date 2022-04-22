using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingExample : MonoBehaviour
{
    [SerializeField] int objectCount;

    List<GameObject> spheres = new List<GameObject>();

    Vector2 maximumPos;

    void Start()
    {
        FindWindowLimits();
        //for (int i = 0; i < objectCount; i++)
        //{
        //    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //    sphere.transform.position = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
        //}

    }

    void Update()
    {
        if (spheres.Count < objectCount)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Collider col = sphere.GetComponent<Collider>();
            col.enabled = false;
            Destroy(col);
            sphere.transform.position = new Vector2(GaussianRandom(-maximumPos.x, maximumPos.x), GaussianRandom(-maximumPos.y, maximumPos.y));
            spheres.Add(sphere);
        }
    }


    float GaussianRandom(float min, float max)
    {
        return Random.Range(Random.Range(min, max), Random.Range(min, max));
    }


    void FindWindowLimits()
    {
        Camera.main.orthographic = true;

        maximumPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
}
