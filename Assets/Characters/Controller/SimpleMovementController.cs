using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A simple movement controller that moves relative to a provided target location.
 * 
 * Requires a TargetProvider to provide a point to turn towards and move relative to.
 */
public class SimpleMovementController : MovementController
{
    public TargetProvider targetProvider;

    public float jumpTime = 1f;
    public float jumpSpeed = 9.8f;

    private FA_InputActions inputActions;
    private Vector2 move;
    private Vector2 rotate;
    private float jumpStarted;
    private float movementSpeed;

    void Start()
    {
        movementSpeed = walkingSpeed;
        jumpStarted = -1f;

        //- Bind Input Events ----------------------------=
        //
        inputActions = GameManager.GetInputActions();
        //
        // Jump
        inputActions.Player.Jump.performed += ctx => InitiateJump();
        //
        // Movement Speed - use runSpeed if button pressed
        inputActions.Player.Run.performed += ctx => movementSpeed = runningSpeed;
        inputActions.Player.Run.canceled += ctx => movementSpeed = walkingSpeed;
        //
        // Movement Direction - use captured vector if input axis is set, zero if not
        inputActions.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => move = Vector2.zero;
    }

    // Update is called once per frame
    void Update() {
        ApplyRotation();

        ApplyMovement();

        ApplyJump();
    }

    private void ApplyRotation() {
        if (!targetProvider) { return; }

        // Determine desired rotation
        Quaternion targetRotation;
        if (targetProvider.IsTargetingLocationValid()) {
            Vector3 deltaPosition = targetProvider.GetTargetingLocation() - transform.position;
            targetRotation = Quaternion.LookRotation(deltaPosition, Vector3.up);
        } else {
            Vector3 direction = targetProvider.GetTargetingLocation() - transform.position;
            targetRotation = Quaternion.Euler(direction);
        }

        ApplyRotation2D(targetRotation);
    }

    private void ApplyMovement() {
        Vector2 applyMove = Vector2.ClampMagnitude(move, 1);
        transform.Translate(Vector3.right * Time.deltaTime * applyMove.x * movementSpeed, Space.Self);
        transform.Translate(Vector3.forward * Time.deltaTime * applyMove.y * movementSpeed, Space.Self);

    }

    private void ApplyJump() {
        // Going Up
        if (jumpStarted + (jumpTime / 2) > Time.time) {
            transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime, Space.Self);
        }
        // Going Down
        else if (jumpStarted + jumpTime > Time.time) {
            transform.Translate(Vector3.up * -jumpSpeed * Time.deltaTime, Space.Self);
        }
    }

    private void InitiateJump()
    {
        if (jumpStarted + jumpTime < Time.time)
        {
            jumpStarted = Time.time;
        }
    }
}
