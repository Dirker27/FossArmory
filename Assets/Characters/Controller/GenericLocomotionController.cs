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

    // Start is called before the first frame update
    void Start()
    {
        if (! TryGetComponent<Animator>(out animator)) {
            Debug.LogError("Missing Required Component: Animator");
        }
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
}
