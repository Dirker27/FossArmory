using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementAccelleration = 5f;
    public float movementDecelleration = 3f;

    public float walkingSpeed = 1f;
    public float joggingSpeed = 3f;
    public float runningSpeed = 7f;
    public float turningSpeed = 2f;

    public bool isWalking = false;
    public bool isRunning = false;
    public bool isCrouched = false;

    protected Vector3 currentMovementVelocity = Vector3.zero;
    protected float currentRotationVelocity = 0f;

    private Vector3 decellerationJerk = Vector3.zero;
    private static float ZERO_THRESHOLD = 0.03f;

    /**
     * Moves the parent transform on the x/z plane on an accelleration-based model
     */
    protected void ApplyMovement2D(Vector2 movement) {
        float decelleration = movementDecelleration * Time.deltaTime;
        
        float topSpeed = isWalking ? walkingSpeed : joggingSpeed;
        topSpeed = isRunning ? runningSpeed : topSpeed;

        //- Dampen / Decellerate -------------------------=
        //
        // X
        if (currentMovementVelocity.x != 0) {
            if (currentMovementVelocity.x > 0) {
                currentMovementVelocity.x -= decelleration;
            } else {
                currentMovementVelocity.x += decelleration;
            }
        }
        if (Mathf.Abs(currentMovementVelocity.x) < ZERO_THRESHOLD) { currentMovementVelocity.x = 0; }
        //
        // Z (y == z)
        if (currentMovementVelocity.z != 0) {
            if (currentMovementVelocity.z > 0) {
                currentMovementVelocity.z -= decelleration;
            } else {
                currentMovementVelocity.z += decelleration;
            }
        }
        if (Mathf.Abs(currentMovementVelocity.z) < ZERO_THRESHOLD) { currentMovementVelocity.z = 0; }

        //- Accellerate to Top Speed ---------------------=
        //
        float dx = movement.x * movementAccelleration * Time.deltaTime;
        float dy = movement.y * movementAccelleration * Time.deltaTime;
        //if (currentVelocity.magnitude < topSpeed) {
            currentMovementVelocity.x += dx;
            currentMovementVelocity.z += dy;
        //}
        currentMovementVelocity = Vector3.ClampMagnitude(currentMovementVelocity, topSpeed);

        transform.Translate(currentMovementVelocity * Time.deltaTime);
    }

    /**
     * Turns towards a given target point locked on the Y-axis.
     */
    protected void ApplyRotation2D(Quaternion targetRotation) {
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
        float yDelta = Mathf.SmoothDamp(baseAngle, yDiff, ref currentRotationVelocity, turningSpeed);
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
}
