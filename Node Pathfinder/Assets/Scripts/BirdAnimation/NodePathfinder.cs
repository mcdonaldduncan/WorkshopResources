using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class NodePathfinder : MonoBehaviour
{
    [SerializeField] NodePath path;
    [SerializeField] float m_Speed;

    int index;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
#endif

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
        if (index >= path.m_Nodes.Length)
            return;

        float step = m_Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, path.m_Nodes[index].position, step);

        if (Vector3.Distance(transform.position, path.m_Nodes[index].position) < .5f)
            index++;
    }
}
