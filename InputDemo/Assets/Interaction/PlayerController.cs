using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // default generated script
    static InputActions _input;

    Vector3 moveValue;
    float moveSpeed = 5f;

    private void Awake()
    {
        _input = new InputActions();
        moveValue = Vector3.zero;
    }

    private void OnEnable()
    {
        _input.Player.Enable();
        _input.Player.Move.performed += HandleMovement;
        _input.Player.Move.canceled += HandleMovement;
    }

    private void OnDisable()
    {
        _input.Player.Move.performed -= HandleMovement;
        _input.Player.Move.canceled -= HandleMovement;
        _input.Player.Disable();
    }

    private void Update()
    {
        if (moveValue == Vector3.zero) return;
        transform.Translate(moveSpeed * Time.deltaTime * moveValue);
    }

    void HandleMovement(InputAction.CallbackContext context)
    {
        Vector2 current = context.ReadValue<Vector2>();
        moveValue = new Vector3(current.x, 0, current.y);
    }
    
}
    