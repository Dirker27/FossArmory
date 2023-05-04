using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/**
 * Manages equipment currently stored on a given Pawn's body.
 * 
 * Requires MountPoints to visibly store weapons.
 */
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
                Debug.Log("Instantiating Primary Weapon [" + primaryWeapon.name + "]");
                primaryWeapon = GameObject.Instantiate(primaryWeapon, transform);
            }
            EquipToPrimaryWeaponHand(primaryWeapon);            
        }

        if (holsteredWeapon) {
            if (!holsteredWeapon.isActiveAndEnabled) {
                Debug.Log("Instantiating Secondary Weapon [" + holsteredWeapon.name + "]");
                holsteredWeapon = GameObject.Instantiate(holsteredWeapon, transform);
            }
            EquipToSecondaryHolster(holsteredWeapon);
        }

        if (backWeapon) {
            if (!backWeapon.isActiveAndEnabled) {
                Debug.Log("Instantiating Back Weapon [" + backWeapon.name + "]");
                backWeapon = GameObject.Instantiate(backWeapon, transform);
            }
            EquipToBack(backWeapon);
        }
    }

    public void EquipToPrimaryWeaponHand(Weapon weapon) {
        currentWeapon = weapon;

        if (weapon && weapon.TryGetComponent<Mountable>(out Mountable m)) {
            m.Mount(primaryWeaponHand);
        }
    }

    public void EquipToSecondaryHolster(Weapon weapon) {
        holsteredWeapon = weapon;

        if (weapon && weapon.TryGetComponent<Mountable>(out Mountable m)) {
            m.Mount(leftHolster);
        }
    }

    public void EquipToBack(Weapon weapon) {
        backWeapon = weapon;

        if (weapon && weapon.TryGetComponent<Mountable>(out Mountable m)) {
            m.Mount(backHolster);
        }
    }
}
