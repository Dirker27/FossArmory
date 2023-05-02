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

    public void Ready()
    {
        foreach (Weapon weapon in activeWeapons)
        {
            Debug.Log("[Player Action] READYING WEAPON: [" + weapon.name + "]");
            weapon.Ready();
        }
    }

    public void CancelReady()
    {
        foreach (Weapon weapon in activeWeapons)
        {
            Debug.Log("[Player Action] UN-READYING WEAPON: [" + weapon.name + "]");
            weapon.CancelReady();
        }
    }

    public void Aim()
    {
        foreach (Weapon weapon in activeWeapons)
        {
            Debug.Log("[Player Action] AIMING WEAPON: [" + weapon.name + "]");
            weapon.Aim();
        }
    }

    public void CancelAim()
    {
        foreach (Weapon weapon in activeWeapons)
        {
            Debug.Log("[Player Action] UN-AIMING WEAPON: [" + weapon.name + "]");
            weapon.CancelAim();
        }
    }

    public void Fire()
    {
        foreach(Weapon weapon in activeWeapons)
        {
            Debug.Log("[Player Action] FIRING WEAPON: [" + weapon.name + "]");
            weapon.Fire();
        }
    }

    public void CancelFire() {
        foreach (Weapon weapon in activeWeapons) {
            Debug.Log("[Player Action] CEASE-FIRING WEAPON: [" + weapon.name + "]");
            weapon.CancelFire();
        }
    }
}
