using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A given pawn's loadout
 */
public class Loadout : MonoBehaviour {
    public Weapon primaryWeapon;
    public Weapon secondaryWeapon;
    public Weapon tertiaryWeapon;

    public Throwable tacticalThrowable;
    public Throwable lethalThrowable;

    public Weapon GetWeaponFromEquipmentSlot(EquipmentSlot slot) {
        switch (slot) {
            case EquipmentSlot.PrimaryWeapon:
                return primaryWeapon;
            case EquipmentSlot.SecondaryWeapon:
                return secondaryWeapon;
            case EquipmentSlot.TertiaryWeapon:
                return tertiaryWeapon;
            case EquipmentSlot.LethalThrowable:
                return lethalThrowable;
            case EquipmentSlot.TacticalThrowable:
                return tacticalThrowable;
            case EquipmentSlot.None:
            default:
                return null;
        }
    }
}
