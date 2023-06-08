using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A generic weapon that can be equipped and used by Pawns
 */
public abstract class Weapon : MonoBehaviour,
    Equipable, Usable
{
    
    public WeaponConfiguration weaponConfiguration;

    public bool isArmed;
    public bool isAiming;

    private WeaponAim weaponAim;
    private Mountable mountable;

    void Start() {
        TryGetComponent<WeaponAim>(out weaponAim);
        TryGetComponent<Mountable>(out mountable);
    }

    public virtual void Equip() {

    }

    public virtual void UnEquip() {

    }

    public virtual void Use() {
        Fire();
    }

    public virtual void Arm()
    {
        isArmed = true;
    }

    public virtual void CancelArm()
    {
        isArmed = false;
    }

    public void Aim()
    {
        isAiming = true;
        if (weaponAim) { weaponAim.SetTargetLockEnabled(true); }

        if (mountable) {
            mountable.applyRotation = false;
        }
    }

    public void CancelAim()
    {
        isAiming = false;
        if (weaponAim) { weaponAim.SetTargetLockEnabled(false); }

        if (mountable) {
            mountable.applyRotation = true;
        }
    }

    public abstract void Fire();

    public abstract void CancelFire();
}
