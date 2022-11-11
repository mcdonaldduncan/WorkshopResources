using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Subject
{
    [SerializeField] float scale = .1f;
    [SerializeField] float rotateAmount = 1f;
    [SerializeField] GameObject dronePrefab;
    [SerializeField] GameObject floor;

    Bounds bounds;

    private Transform playerTransform;
   
    private ObserverDemoPlayer inputActions;
    bool rotatePlayer = false;

    private void Awake()
    {
        inputActions = new ObserverDemoPlayer();
        inputActions.Player.Move.performed += Move_performed;
        inputActions.Player.Move.started += Move_started;
        inputActions.Player.Move.canceled += Move_canceled;
        inputActions.Player.Fire.performed += Fire_performed;
    }
    void Start()
    {
        playerTransform = transform;
        bounds = floor.GetComponent<Collider>().bounds;
    }

    private void Move_canceled(InputAction.CallbackContext obj)
    {
        rotatePlayer = false;
        StopCoroutine(RotatePlayer());
    }

    private void Move_started(InputAction.CallbackContext obj)
    {
        if (obj.control.name == "r")
        {
            rotatePlayer = true;
            StartCoroutine(RotatePlayer());      
        }
        
    }
    
    IEnumerator RotatePlayer()
    {
        while (rotatePlayer)
        {
            playerTransform.Rotate(0, rotateAmount, 0);
            yield return new WaitForSeconds(.1f);
        }
        //NotifyObservers(playerTransform.transform.right);
        NotifyObservers();
        yield return null;
    }

    private void Fire_performed(InputAction.CallbackContext obj)
    {
        GameObject tempDrone = Instantiate(dronePrefab);

        float x = UnityEngine.Random.Range(bounds.max.x, bounds.min.x);
        float z = UnityEngine.Random.Range(bounds.max.z, bounds.min.z);

        tempDrone.transform.position = new Vector3(x, .2f, z);
        
        Drone drone = tempDrone.GetComponent<Drone>();
        Attach(drone);
    }
    

    /// <summary>
    /// ASDW movement
    /// </summary>
    /// <param name="obj"></param>
    private void Move_performed(InputAction.CallbackContext obj)
    {
        if (obj.control.name != "r")
        {
            playerTransform.Translate(this.transform.forward * scale);
        }
    }

    
    private void OnEnable()
    {
        inputActions.Enable();
        GameObject[] drones = GameObject.FindGameObjectsWithTag("Drone");
        foreach (GameObject drone in drones)
        {
            Drone droneScriptComponent = drone.GetComponent<Drone>();
            Attach(droneScriptComponent);
        }

    }
    private void OnDisable()
    {
        inputActions.Disable();
        GameObject[] drones = GameObject.FindGameObjectsWithTag("Drone");
        foreach (GameObject drone in drones)
        {
            Drone droneScriptComponent = drone.GetComponent<Drone>();
            Detach(droneScriptComponent);
        }
    }

    

}

