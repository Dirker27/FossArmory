using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * A Movement Controller for Humanoid Pawns.
 * 
 * Adds additional states for whether a Humanoid is armed.
 */
public class HumanoidMovementController : MovementController
{
    //public TargetProvider targetProvider;

    void Start() {
        /*if (!targetProvider) {
            Debug.LogError("Missing Required Component: TargetProvider");
        }*/
    }

    // TODO: Migrate walking/crouching/running logic to here

    /*public float walkingSpeed = 1f;
    public float joggingSpeed = 3f;
    public float runningSpeed = 7f;
    public float turningSpeed = 2f;

    public bool isWalking = false;
    public bool isRunning = false;
    public bool isCrouched = false;*/

    public bool isArmed = false;
    public bool isAiming = false;

    // Update is called once per frame
    void Update()
    {
        ApplyMovement2D(Vector2.ClampMagnitude(inputMovement, 1));

        /*if (targetProvider) {
            ApplyRotation2D(Quaternion.LookRotation(targetProvider.GetTargetingDirection()));
        }*/
    }
}
