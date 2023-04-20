using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * Controls Animation States for the Generic Locomotion animator.
 */
public class GenericLocomotionController : MovementController
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

        Vector2 animVelocity = new Vector2(currentMovementVelocity.x, currentMovementVelocity.z);
        animator.SetFloat("VelX", currentMovementVelocity.x);
        animator.SetFloat("VelZ", currentMovementVelocity.z);
        animator.SetFloat("VelMagnitude", animVelocity.magnitude);
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