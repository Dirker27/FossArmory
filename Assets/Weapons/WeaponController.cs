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

    public bool isReady = false;
    public bool isAiming = false;

    public void Ready()
    {
        isReady = true;

        foreach (Weapon weapon in activeWeapons)
        {
            FADebug.Log(FADebug.LogLevel.INFO, "[Player Action] READYING WEAPON: [" + weapon.name + "]");
            weapon.Arm();
        }
    }

    public void CancelReady()
    {
        isReady = false;

        foreach (Weapon weapon in activeWeapons)
        {
            FADebug.Log(FADebug.LogLevel.INFO, "[Player Action] UN-READYING WEAPON: [" + weapon.name + "]");
            weapon.CancelArm();
        }
    }

    public void Aim()
    {
        isAiming = true;

        foreach (Weapon weapon in activeWeapons)
        {
            FADebug.Log(FADebug.LogLevel.INFO, "[Player Action] AIMING WEAPON: [" + weapon.name + "]");
            weapon.Aim();
        }
    }

    public void CancelAim()
    {
        isAiming = false;

        foreach (Weapon weapon in activeWeapons)
        {
            FADebug.Log(FADebug.LogLevel.INFO, "[Player Action] UN-AIMING WEAPON: [" + weapon.name + "]");
            weapon.CancelAim();
        }
    }

    public void Fire()
    {
        foreach(Weapon weapon in activeWeapons)
        {
            string logMessage = string.Format("[Player Action] FIRING WEAPON: [{0}]", weapon.name);
            FADebug.Log(FADebug.LogLevel.INFO, logMessage);
            weapon.Fire();
        }
    }

    public void CancelFire() {
        foreach (Weapon weapon in activeWeapons) {
            FADebug.Log(FADebug.LogLevel.INFO, "[Player Action] CEASE-FIRING WEAPON: [" + weapon.name + "]");
            weapon.CancelFire();
        }
    }
}
