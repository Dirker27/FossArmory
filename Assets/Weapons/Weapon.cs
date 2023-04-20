using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour,
    Equipable, Usable
{
    
    public WeaponConfiguration weaponConfiguration;

    public bool isArmed;
    public bool isAiming;

    private WeaponAim weaponAim;

    void Start() {
        if (!TryGetComponent<WeaponAim>(out weaponAim)) {
            Debug.LogError("Missing Required Component: WeaponAim");
        }
    }

    public virtual void Equip() {

    }

    public virtual void UnEquip() {

    }

    public virtual void Use() {
        Fire();
    }

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
}
