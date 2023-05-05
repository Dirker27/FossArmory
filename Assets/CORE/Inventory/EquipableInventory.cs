using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/**
 * Manages equipment currently stored on a given Pawn's body.
 * 
 * Requires MountPoints to visibly store weapons.
 */
public class EquipableInventory : MonoBehaviour {
    public MountPoint primaryWeaponHand;
    public MountPoint secondaryWeaponHand;

    public MountPoint leftHolster;
    public MountPoint rightHolster;
    public MountPoint backHolster;
    public MountPoint rightBeltHolster;
    public MountPoint leftBeltHolster;
    public MountPoint rightChestHolster;
    public MountPoint leftChestHolster;

    public void EquipToPrimaryWeaponHand(Weapon weapon) {
        if (weapon && weapon.TryGetComponent<Mountable>(out Mountable m)) {
            m.Mount(primaryWeaponHand);
        }
    }

    public void EquipToSecondaryWeaponHand(Weapon weapon) {
        if (weapon && weapon.TryGetComponent<Mountable>(out Mountable m)) {
            m.Mount(secondaryWeaponHand);
        }
    }

    public void EquipToPrimaryHolster(Weapon weapon) {
        if (weapon && weapon.TryGetComponent<Mountable>(out Mountable m)) {
            m.Mount(rightHolster);
        }
    }

    public void EquipToSecondaryHolster(Weapon weapon) {
        if (weapon && weapon.TryGetComponent<Mountable>(out Mountable m)) {
            m.Mount(leftHolster);
        }
    }

    public void EquipToBackHolster(Weapon weapon) {
        if (weapon && weapon.TryGetComponent<Mountable>(out Mountable m)) {
            m.Mount(backHolster);
        }
    }

    public void EquipToLethalHolster(Weapon weapon) {
        if (weapon && weapon.TryGetComponent<Mountable>(out Mountable m)) {
            m.Mount(rightBeltHolster);
        }
    }

    public void EquipToTacticalHolster(Weapon weapon) {
        if (weapon && weapon.TryGetComponent<Mountable>(out Mountable m)) {
            m.Mount(leftBeltHolster);
        }
    }
}
