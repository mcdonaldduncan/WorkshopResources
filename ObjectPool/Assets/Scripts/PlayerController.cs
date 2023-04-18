using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject BallPrefab;
    [SerializeField] float force;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotSpeed;
    [SerializeField] float fireDelay;
    [SerializeField] float launchY;

    BallObjectPool _pool;
    InputActionScript _actionScript;

    float moveValueX;
    float moveValueY;

    float lastShotTime;

    float nextShotTime => lastShotTime + fireDelay;

    bool fireHeld;

    Vector3 offsetStart => transform.position + transform.up + transform.forward;

    private void Awake()
    {
        _actionScript = new InputActionScript();
    }

    void Start()
    {
        _pool = gameObject.AddComponent<BallObjectPool>();
        _pool.ballPrefab = BallPrefab;
    }

    private void OnEnable()
    {
        _actionScript.Player.Enable();
        _actionScript.Player.Move.performed += HandleMovement;
        _actionScript.Player.Move.canceled += HandleMovement;
        _actionScript.Player.Fire.performed += OnFire;
        _actionScript.Player.Fire.canceled += OnFire;
    }

    private void OnDisable()
    {
        _actionScript.Player.Move.performed -= HandleMovement;
        _actionScript.Player.Move.canceled -= HandleMovement;
        _actionScript.Player.Fire.performed -= OnFire;
        _actionScript.Player.Fire.canceled -= OnFire;
        _actionScript.Player.Disable();
    }

    private void Update()
    {
        if (fireHeld && Time.time > nextShotTime)
        {
            Shoot();
        }

        if (moveValueX == 0 && moveValueY == 0) return;
        transform.Translate(moveValueY * moveSpeed * Time.deltaTime * Vector3.forward);
        transform.Rotate(Vector3.up, moveValueX * rotSpeed * Time.deltaTime);
    }

    void HandleMovement(InputAction.CallbackContext context)
    {
        Vector2 current = context.ReadValue<Vector2>();
        moveValueX = current.x;
        moveValueY = current.y;
    }

    void OnFire(InputAction.CallbackContext context)
    {
        fireHeld = context.performed;
    }

    void Shoot()
    {
        Ball currentBall = _pool.TakeFromPool();
        currentBall.transform.position = offsetStart;

        currentBall.Launch(force, transform.forward);
        lastShotTime = Time.time;
    }
    
}
