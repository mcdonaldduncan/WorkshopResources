using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.GetContact(0).normal.y < -.5)
        {
            gameObject.SetActive(false);
        }
    }

}
