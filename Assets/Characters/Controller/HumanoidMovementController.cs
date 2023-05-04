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
    public bool isArmed;
    public bool isAiming;

    // Update is called once per frame
    void Update()
    {
        ApplyMovement2D(Vector2.ClampMagnitude(inputMovement, 1));
    }
}
