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
        ApplyMovement2D(Vector2.ClampMagnitude(inputMovement, 1));

        Vector2 animVelocity = new Vector2(currentVelocity.x, currentVelocity.z);
        animator.SetFloat("VelX", (currentVelocity.x / runningSpeed));
        animator.SetFloat("VelZ", 2 * (currentVelocity.z / runningSpeed));
        animator.SetFloat("VelMagnitude", animVelocity.magnitude / runningSpeed);
        animator.SetBool("IsRunning", isRunning);
        animator.SetBool("IsCrouched", isCrouched);
    }

    private void BindInput(FA_InputActions inputActions) {
        // Movement
        inputActions.Player.Move.performed += ctx => inputMovement = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => inputMovement = Vector2.zero;
        // Sprint
        inputActions.Player.Run.performed += ctx => isRunning = true;
        inputActions.Player.Run.canceled += ctx => isRunning = false;
        // Crouch
        inputActions.Player.Crouch.performed += ctx => isCrouched = true;
        inputActions.Player.Crouch.canceled += ctx => isCrouched = false;
        // Rotation
        inputActions.Player.Look.performed += ctx => inputRotation = ctx.ReadValue<Vector2>();
        inputActions.Player.Look.canceled += ctx => inputRotation = Vector2.zero;
    }
}
