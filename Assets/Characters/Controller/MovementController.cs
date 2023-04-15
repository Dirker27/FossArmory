using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementAccelleration = 3f;
    public float movementDecelleration = 1f;
    public float walkingSpeed = 3f;
    public float runningSpeed = 7f;
    public float turningSpeed = 2f;
    public bool isRunning = false;
    public bool isCrouched = false;

    public float ZERO_THRESHOLD = 0.03f;

    protected Vector3 currentVelocity;
    protected Vector3 currentRotationSpeed;

    private Vector3 decellerationJerk = Vector3.zero;

    protected void ApplyMovement2D(Vector2 movement) {
        float decelleration = movementDecelleration * Time.deltaTime;
        float topSpeed = isRunning ? runningSpeed : walkingSpeed;

        //- Dampen / Decellerate -------------------------=
        //
        // X
        if (currentVelocity.x != 0) {
            if (currentVelocity.x > 0) {
                currentVelocity.x -= decelleration;
            } else {
                currentVelocity.x += decelleration;
            }
        }
        if (Mathf.Abs(currentVelocity.x) < ZERO_THRESHOLD) { currentVelocity.x = 0; }
        //
        // Z (y == z)
        if (currentVelocity.z != 0) {
            if (currentVelocity.z > 0) {
                currentVelocity.z -= decelleration;
            } else {
                currentVelocity.z += decelleration;
            }
        }
        if (Mathf.Abs(currentVelocity.z) < ZERO_THRESHOLD) { currentVelocity.z = 0; }

        //- Accellerate to Top Speed ---------------------=
        //
        float dx = movement.x * movementAccelleration * Time.deltaTime;
        float dy = movement.y * movementAccelleration * Time.deltaTime;
        Vector2 delta = new Vector2(dx, dy);
        //if (delta.magnitude > 0) {
            if (currentVelocity.magnitude < topSpeed) {
                currentVelocity.x += dx;
                currentVelocity.z += dy;
            }
        //}
        //currentVelocity = Vector3.ClampMagnitude(currentVelocity, topSpeed);

        Debug.Log("Applying movement: " + movement + " :: [" + currentVelocity + "]");
        transform.Translate(currentVelocity * Time.deltaTime);
    }
}
