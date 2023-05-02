using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HumanoidLocomotionController : MovementController
{
    public Animator animator;

    public bool isArmed;
    public bool isAiming;

    // Start is called before the first frame update
    void Start()
    {
        if (!animator) {
            if (!TryGetComponent<Animator>(out animator)) {
                Debug.LogError("Missing Required Component: Animator"); 
            }
        }

        BindInput(GameManager.GetInputActions());
    }

    // Update is called once per frame
    void Update()
    {
        ApplyMovement2D(Vector2.ClampMagnitude(inputMovement, 1));

        Vector2 animVelocity = new Vector2(currentMovementVelocity.x, currentMovementVelocity.z);
        
        // TODO: Set w/ HashCode
        animator.SetFloat("VelX", currentMovementVelocity.x);
        animator.SetFloat("VelZ", currentMovementVelocity.z);
        animator.SetFloat("VelMagnitude", animVelocity.magnitude);
        animator.SetBool("IsWalking", isWalking);
        animator.SetBool("IsRunning", isRunning);
        animator.SetBool("IsCrouched", isCrouched);
        animator.SetBool("IsArmed", isArmed);

        animator.SetLayerWeight(0, isCrouched ? 0 : 1);
        animator.SetLayerWeight(1, isCrouched ? 1 : 0);
        animator.SetLayerWeight(2, isArmed ? 1 : 0);
    }

    private void BindInput(FA_InputActions inputActions) {
        // Ready Weapon (Toggle)
        inputActions.Player.Ready.performed += ctx => isArmed = !isArmed;
        // Aim Weapon (Hold)
        inputActions.Player.Aim.performed += ctx => isAiming = true;
        inputActions.Player.Aim.canceled += ctx => isAiming = false;
    }
}
