using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePathfinder : MonoBehaviour
{
    [SerializeField] Transform[] nodes;
    [SerializeField] float speed;

    int index;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        NodeFollow();
    }

    void NodeFollow()
    {
        float distance = Vector3.Distance(transform.position, nodes[index].position);
        float step = speed * Time.deltaTime;

        if (distance < .1f)
        {
            index++;
        }

        if (index == nodes.Length)
        {
            index = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, nodes[index].position, step);

    }
}
