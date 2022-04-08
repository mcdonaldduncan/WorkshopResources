using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePathfinder : MonoBehaviour
{
    [SerializeField] Transform[] nodes;
    [SerializeField] float speed;
    [SerializeField] int index;

    [System.NonSerialized] public bool shouldDestroy;
    [System.NonSerialized] public bool shouldMove;

    void Start()
    {
        index = 0;
        shouldDestroy = false;
        shouldMove = false;
    }

    void Update()
    {
        if (shouldMove)
            FollowNodes();
    }

    void FollowNodes()
    {
        if (Vector3.Distance(transform.position, nodes[index].position) < 1f)
            index++;
        if (index == nodes.Length)
            shouldDestroy = true;

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, nodes[index].position, step);
    }
}
