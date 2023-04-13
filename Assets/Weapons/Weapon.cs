using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Animation cycleAnimation;

    public bool isArmed;
    public bool isAiming;

    private WeaponAim weaponAim;

    public void Ready()
    {
        isArmed = true;
    }

    public void CancelReady()
    {
        isArmed = false;
    }

    public void Aim()
    {
        isAiming = true;
        if (weaponAim) { weaponAim.SetTargetLock(true); }
    }

    public void CancelAim()
    {
        isAiming = false;
        if (weaponAim) { weaponAim.SetTargetLock(false); }
    }

    public abstract void Fire();

    void Start()
    {
        weaponAim = GetComponent<WeaponAim>();
        if (!weaponAim)
        {
            Debug.LogError("Missing Required Component: WeaponAim");
        }
    }

    void Update()
    {
        
    }
}
