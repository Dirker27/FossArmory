using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class InputDelegate {

    private FA_InputActions inputActions;

    public MovementController movementController;
    public EquipmentController equipmentController;
    public WeaponController weaponController;

    public InputDelegate(FA_InputActions inputActions) {
        this.inputActions = inputActions;
        BindInputActions();
    }

    public void BindInputToPawn(Pawn pawn) {
        movementController = pawn.movementController;
        equipmentController = pawn.equipmentController;
        weaponController = pawn.weaponController;
    }

    public void Release() {
        movementController = null;
        equipmentController = null;
        weaponController = null;
    }

    public void BindInputActions() {

        //- MOVEMENT CONTROLLER --------------------------=
        //
        // Movement
        inputActions.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        inputActions.Player.Move.canceled += ctx => CancelMove();
        // Walk
        inputActions.Player.Walk.performed += ctx => Walk();
        inputActions.Player.Walk.canceled += ctx => CancelWalk();
        // Sprint
        inputActions.Player.Run.performed += ctx => Run();
        inputActions.Player.Run.canceled += ctx => CancelRun();
        // Crouch
        inputActions.Player.Crouch.performed += ctx => Crouch();
        inputActions.Player.Crouch.canceled += ctx => CancelCrouch();
        // Rotation
        inputActions.Player.Look.performed += ctx => Look(ctx.ReadValue<Vector2>());
        inputActions.Player.Look.canceled += ctx => CancelLook();

        //- EQUIPMENT CONTROLLER -------------------------=
        //
        inputActions.Player.WeaponSelect.performed += ctx => WeaponSwap();
        inputActions.Player.EquipmentSelect.performed += ctx => EquipmentSwap();

        //- WEAPON CONTROLLER ----------------------------=
        //
        // Fire Weapon
        inputActions.Player.Ready.performed += ctx => ReadyWeapon();
        inputActions.Player.Ready.canceled += ctx => CancelReadyWeapon();
        // Fire Weapon
        inputActions.Player.Aim.performed += ctx => AimWeapon();
        inputActions.Player.Aim.canceled += ctx => CancelAimWeapon();
        // Fire Weapon
        inputActions.Player.Fire.performed += ctx => FireWeapon();
        inputActions.Player.Fire.canceled += ctx => CancelFireWeapon();
    }

    /* ==============================================================
     * MOVEMENT CONTROLLER ACTIONS
     * ============================================================ */

    private void Move(Vector2 movement) {
        if (!movementController) { return; }
        movementController.Move(movement);
    }

    private void CancelMove() {
        if (!movementController) { return; }
        movementController.CancelMove();
    }

    private void Look(Vector2 rotation) {
        if (!movementController) { return; }
        movementController.Look(rotation);
    }

    private void CancelLook() {
        if (!movementController) { return; }
        movementController.CancelLook();
    }

    private void Walk() {
        if (!movementController) { return; }
        movementController.Walk();
    }

    private void CancelWalk() {
        if (!movementController) { return; }
        movementController.CancelWalk();
    }

    private void Run() {
        if (!movementController) { return; }
        movementController.Run();
    }

    private void CancelRun() {
        if (!movementController) { return; }
        movementController.CancelRun();
    }

    private void Crouch() {
        if (!movementController) { return; }
        movementController.Crouch();
    }

    private void CancelCrouch() {
        if (!movementController) { return; }
        movementController.CancelCrouch();
    }

    /* ==============================================================
     * EQUIPMENT CONTROLLER ACTIONS
     * ============================================================ */

    private void WeaponSwap() {
        if (!equipmentController) { return; }
        equipmentController.WeaponSwap();
    }

    private void EquipmentSwap() {
        if (!equipmentController) { return; }
        equipmentController.EquipmentSwap();
    }

    /* ==============================================================
     * WEAPON CONTROLLER ACTIONS
     * ============================================================ */

    private void ReadyWeapon() {
        if (!weaponController) { return; }
        weaponController.Ready();
    }

    private void CancelReadyWeapon() {
        if (!weaponController) { return; }
        weaponController.CancelReady();
    }

    private void AimWeapon() {
        if (!weaponController) { return; }
        weaponController.Aim();
    }

    private void CancelAimWeapon() {
        if (!weaponController) { return; }
        weaponController.CancelAim();
    }

    private void FireWeapon() {
        if (!weaponController) { return; }
        weaponController.Fire();
    }

    private void CancelFireWeapon() {
        if (!weaponController) { return; }
        weaponController.CancelFire();
    }
}
