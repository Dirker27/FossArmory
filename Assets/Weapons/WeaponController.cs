using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * Controls weapon actions and animations.
 */
public class WeaponController : MonoBehaviour
{
    public List<Weapon> activeWeapons = new List<Weapon>();

    private FA_InputActions inputActions;

    private void Awake()
    {
        //- Bind Input Events ----------------------------=
        //
        inputActions = new FA_InputActions();
        //
        // Fire Weapon
        inputActions.Player.Ready.performed += ctx => Ready();
        inputActions.Player.Ready.canceled += ctx => UnReady();
        // Fire Weapon
        inputActions.Player.Aim.performed += ctx => Aim();
        inputActions.Player.Aim.canceled += ctx => UnAim();
        // Fire Weapon
        inputActions.Player.Fire.performed += ctx => Fire();
    }

    private void Ready()
    {
        foreach (Weapon weapon in activeWeapons)
        {
            Debug.Log("[Player Action] READYING WEAPON: [" + weapon.name + "]");
            weapon.Ready();
        }
    }

    private void UnReady()
    {
        foreach (Weapon weapon in activeWeapons)
        {
            Debug.Log("[Player Action] UN-READYING WEAPON: [" + weapon.name + "]");
            weapon.CancelReady();
        }
    }

    private void Aim()
    {
        foreach (Weapon weapon in activeWeapons)
        {
            Debug.Log("[Player Action] AIMING WEAPON: [" + weapon.name + "]");
            weapon.Aim();
        }
    }

    private void UnAim()
    {
        foreach (Weapon weapon in activeWeapons)
        {
            Debug.Log("[Player Action] UN-AIMING WEAPON: [" + weapon.name + "]");
            weapon.CancelAim();
        }
    }

    private void Fire()
    {
        foreach(Weapon weapon in activeWeapons)
        {
            Debug.Log("[Player Action] FIRING WEAPON: [" + weapon.name + "]");
            weapon.Fire();
        }
    }
}
