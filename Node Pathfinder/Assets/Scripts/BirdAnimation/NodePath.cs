using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePath : MonoBehaviour
{
    [SerializeField] public Transform[] m_Nodes;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 lastPosition = transform.position;
        foreach (var _transform in m_Nodes)
        {
            Gizmos.DrawSphere(_transform.position, .5f);
            if (lastPosition != transform.position)
            {
                Gizmos.DrawLine(lastPosition, _transform.position);
            }
            lastPosition = _transform.position;
        }

        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
#endif
}
