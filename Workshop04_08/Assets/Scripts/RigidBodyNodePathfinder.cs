using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyNodePathfinder : MonoBehaviour
{
    [SerializeField] Transform[] nodes;
    [SerializeField] float speed;
    [SerializeField] float forceModifier;

    int index;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        NodeFollow();
    }

    void NodeFollow()
    {
        float distance = Vector3.Distance(transform.position, nodes[index].position);

        if (distance < .5f)
        {
            index++;
        }

        if (index == nodes.Length)
        {
            index = 0;
        }

        Vector3 force = nodes[index].position - transform.position;
        force.Normalize();
        force *= forceModifier;

        rb.AddForce(force, ForceMode.Force);


        //float distance = Vector3.Distance(transform.position, nodes[index].position);
        //float step = speed * Time.deltaTime;

        //if (distance < .1f)
        //{
        //    index++;
        //}

        //if (index == nodes.Length)
        //{
        //    index = 0;
        //}

        //transform.position = Vector3.MoveTowards(transform.position, nodes[index].position, step);

    }
}
