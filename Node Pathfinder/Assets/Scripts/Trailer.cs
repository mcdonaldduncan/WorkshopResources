using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trailer : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float trailAmount;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 0, trailAmount);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.localPosition - offset;
    }
}
