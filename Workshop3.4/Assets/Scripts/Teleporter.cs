using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform exit;

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.position = exit.position;
    }
}
