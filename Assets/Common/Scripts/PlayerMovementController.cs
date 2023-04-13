using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public TargetProvider targetProvider;

    public float walkSpeed = 3f;
    public float runSpeed = 10f;
    public float turnSpeed = 1f;
    public float jumpTime = 1f;
    public float jumpSpeed = 9.8f;

    private FA_InputActions inputActions;
    private Vector2 move;
    private Vector2 rotate;
    private float jumpStarted;
    private float movementSpeed;

    public float turnSmoothTime = .3f;
    private float turnVelocity;

    void Start()
    {
        movementSpeed = walkSpeed;
        jumpStarted = -1f;
        turnVelocity = 0f;

        //- Bind Input Events ----------------------------=
        //
        inputActions = GameManager.GetInputActions();
        //
        // Jump
        inputActions.Player.Jump.performed += ctx => InitiateJump();
        //
        // Movement Speed - use runSpeed if button pressed
        inputActions.Player.Run.performed += ctx => movementSpeed = runSpeed;
        inputActions.Player.Run.canceled += ctx => movementSpeed = walkSpeed;
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
        
        // Clamp rotation to shortest direction
        float yDiff = _normalize360(targetRotation.eulerAngles.y - transform.eulerAngles.y);
        /*Debug.Log("Target Player Rotation: " + targetRotation.eulerAngles
            + " :: " + yDiff
            + " From: " + transform.eulerAngles);*/

        // Convert target delta to diff
        float baseAngle = 0;
        if (yDiff > 180) {
            baseAngle = 360;
        } else if (yDiff < -180) {
            baseAngle = -360;
        }
        float yDelta = Mathf.SmoothDamp(baseAngle, yDiff, ref turnVelocity, turnSpeed);
        Vector3 applyRotation = new Vector3(0, yDelta, 0);
        //Debug.Log("Applying Rotation: " + applyRotation);

        // Rotate Transform (conserve physics)
        transform.Rotate(applyRotation);
    }
    private static float _normalize360(float angle) {
        if (angle < -180) {
            return 360 + angle;
        } else if (angle > 180) {
            return -360 + angle;
        }
        return angle;
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
