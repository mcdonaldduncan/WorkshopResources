using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePathfinder : MonoBehaviour
{
    [SerializeField] Transform[] nodes;
    [SerializeField] float speed;
    [SerializeField] int index;
    void Start()
    {
        index = 0;
    }

    void Update()
    {
        FollowNodes();
    }

    void FollowNodes()
    {
        if (Vector3.Distance(transform.position, nodes[index].position) < 1f)
            index++;
        if (index == nodes.Length)
            index = 0;

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, nodes[index].position, step);
    }
}
