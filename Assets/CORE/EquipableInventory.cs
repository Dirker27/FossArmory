using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EquipableInventory : MonoBehaviour
{
    public Loadout loadout;

    public Weapon currentWeapon;

    public Weapon primaryWeapon;
    public Weapon holsteredWeapon;
    public Weapon backWeapon;

    public Throwable tacticalThrowable;
    public Throwable lethalThrowable;

    public MountPoint leftHolster;
    public MountPoint rightHolster;
    public MountPoint backHolster;
    public MountPoint primaryWeaponHand;
    public MountPoint secondaryWeaponHand;

    public void Start() {
        if (primaryWeapon) {
            if (!primaryWeapon.isActiveAndEnabled) {
                Debug.Log("Instantiating Primary Weapon...");
                primaryWeapon = GameObject.Instantiate(primaryWeapon, transform);
            }
            EquipWeapon(primaryWeapon);            
        }

        if (holsteredWeapon) {
            if (!holsteredWeapon.isActiveAndEnabled) {
                Debug.Log("Instantiating Secondary Weapon...");
                holsteredWeapon = GameObject.Instantiate(holsteredWeapon, transform);
            }
            HolsterWeapon(holsteredWeapon);
        }
    }

    public void EquipWeapon(Weapon weapon) {
        currentWeapon = weapon;

        if (weapon.TryGetComponent<Mountable>(out Mountable m)) {
            m.Mount(backHolster);
        }
    }

    public void HolsterWeapon(Weapon weapon) {
        holsteredWeapon = weapon;

        if (weapon.TryGetComponent<Mountable>(out Mountable m)) {
            m.Mount(leftHolster);
        }
    }
}
