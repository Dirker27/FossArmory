using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponLocomotion : MovementController
{
    private Animator animator;

    private Vector2 inputMovement;
    private Vector2 inputRotation;

    // Start is called before the first frame update
    void Start()
    {
        if (! TryGetComponent<Animator>(out animator)) {
            Debug.LogError("Missing Required Component: Animator");
        }

        BindInput(GameManager.GetInputActions());
    }

    // Update is called once per frame
    void Update()
    {
        ApplyMovement(inputMovement);
        animator.SetFloat("VelX", currentSpeed.x);
        animator.SetFloat("VelZ", currentSpeed.y);
    }

    private void BindInput(FA_InputActions inputActions) {
        inputActions.Player.Move.performed += ctx => inputMovement = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => inputMovement = Vector2.zero;
        inputActions.Player.Look.performed += ctx => inputRotation = ctx.ReadValue<Vector2>();
        inputActions.Player.Look.canceled += ctx => inputRotation = Vector2.zero;
    }
}
