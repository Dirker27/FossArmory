using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HumanoidAnimationStateController : MonoBehaviour
{
    public HumanoidMovementController movementController;
    public WeaponController weaponController;
    private Animator animator;

    private static int HASH_VELOCITY_X { get; } = Animator.StringToHash("VelX");
    private static int HASH_VELOCITY_Z { get; } = Animator.StringToHash("VelZ");
    private static int HASH_VELOCITY_MAGNITUDE { get; } = Animator.StringToHash("VelMagnitude");
    private static int HASH_IS_WALKING { get; } = Animator.StringToHash("IsWalking");
    private static int HASH_IS_RUNNING { get; } = Animator.StringToHash("IsRunning");
    private static int HASH_IS_CROUCHED { get; } = Animator.StringToHash("IsCrouched");
    private static int HASH_IS_ARMED { get; } = Animator.StringToHash("IsArmed");

    private static int LAYER_BASE { get; } = 0;
    private static int LAYER_CROUCHED { get; } = 1;
    private static int LAYER_ARMED { get; } = 2;

    // Start is called before the first frame update
    void Start() {
        if (!TryGetComponent<Animator>(out animator)) {
            FADebug.Log(FADebug.LogLevel.ERROR, "Missing Required Component: Animator");
        }

        if (!movementController) {
            FADebug.Log(FADebug.LogLevel.ERROR, "Missing Required Component: HumanoidMovementController");
        }

        if (!weaponController) {
            FADebug.Log(FADebug.LogLevel.ERROR, "Missing Required Component: WeaponController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 animVelocity = new Vector2(movementController.currentMovementVelocity.x, movementController.currentMovementVelocity.z);

        animator.SetFloat(HASH_VELOCITY_X, movementController.currentMovementVelocity.x);
        animator.SetFloat(HASH_VELOCITY_Z, movementController.currentMovementVelocity.z);
        animator.SetFloat(HASH_VELOCITY_MAGNITUDE, animVelocity.magnitude);
        animator.SetBool(HASH_IS_WALKING, movementController.isWalking);
        animator.SetBool(HASH_IS_RUNNING, movementController.isRunning);
        animator.SetBool(HASH_IS_CROUCHED, movementController.isCrouched);
        animator.SetBool(HASH_IS_ARMED, movementController.isArmed);

        animator.SetLayerWeight(LAYER_BASE, movementController.isCrouched ? 0 : 1);
        animator.SetLayerWeight(LAYER_CROUCHED, movementController.isCrouched ? 1 : 0);
        animator.SetLayerWeight(LAYER_ARMED, weaponController.isReady ? 1 : 0);
    }
}
