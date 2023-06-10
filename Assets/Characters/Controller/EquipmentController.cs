using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * Manages active and stored equipment for a given pawn.
 * 
 * Requires an EquipableInventory to store weapons and equipment on a given Pawn's hardpoints.
 */
public class EquipmentController : MonoBehaviour
{
    public EquipmentSlot activeEquipmentSlot;

    private EquipableInventory equipableInventory;
    private WeaponController weaponController;
    private Loadout loadout;

    // Start is called before the first frame update
    void Start()
    {
        if (!TryGetComponent<EquipableInventory>(out equipableInventory)) {
            FADebug.Log(FADebug.LogLevel.ERROR, "Missing Required Component: Equipable Inventory");
        }

        if (!TryGetComponent<WeaponController>(out weaponController)) {
            FADebug.Log(FADebug.LogLevel.ERROR, "Missing Required Component: Weapon Controller");
        }

        if (!TryGetComponent<Loadout>(out loadout)) {
            FADebug.Log(FADebug.LogLevel.ERROR, "Missing Required Component: Loadout");
        }

        InstantiateLoadout();
        equipableInventory.EquipToPrimaryHolster(loadout.primaryWeapon);
        equipableInventory.EquipToSecondaryHolster(loadout.secondaryWeapon);
        equipableInventory.EquipToBackHolster(loadout.tertiaryWeapon);

        activeEquipmentSlot = EquipmentSlot.None;
    }

    public void Ready() {
        activeEquipmentSlot = EquipmentSlot.PrimaryWeapon;
        equipableInventory.EquipToPrimaryWeaponHand(loadout.primaryWeapon);
        
        weaponController.activeWeapons.Add(loadout.primaryWeapon);
        weaponController.Ready();
    }

    public void UnReady() {
        weaponController.CancelReady();
        weaponController.activeWeapons.Clear();

        equipableInventory.EquipToPrimaryHolster(loadout.primaryWeapon);
        equipableInventory.EquipToSecondaryHolster(loadout.secondaryWeapon);
        equipableInventory.EquipToBackHolster(loadout.tertiaryWeapon);

        equipableInventory.EquipToLethalHolster(loadout.lethalThrowable);
        equipableInventory.EquipToTacticalHolster(loadout.tacticalThrowable);
    }

    public void EquipPrimary() {
        UnequipActive();
        EquipAndArm(EquipmentSlot.PrimaryWeapon);
    }
    public void EquipSecondary() {
        UnequipActive();
        EquipAndArm(EquipmentSlot.SecondaryWeapon);
    }
    public void EquipTertiary() {
        UnequipActive();
        EquipAndArm(EquipmentSlot.TertiaryWeapon);
    }
    public void EquipLethalThrowable() {
        UnequipActive();
        EquipAndArm(EquipmentSlot.LethalThrowable);
    }
    public void EquipTacticalThrowable() {
        UnequipActive();
        EquipAndArm(EquipmentSlot.TacticalThrowable);
    }

    public void WeaponSwap() {
        FADebug.Log(FADebug.LogLevel.INFO, "Swapping Weapons...");

        int nextSlot = ((int)activeEquipmentSlot) + 1 % 5;

        UnequipActive();
        EquipAndArm((EquipmentSlot)nextSlot);
    }

    public void EquipmentSwap() {
        FADebug.Log(FADebug.LogLevel.INFO, "Swapping Equipment...");
    }

    private void InstantiateLoadout() {
        if (loadout.primaryWeapon) {
            if (!loadout.primaryWeapon.isActiveAndEnabled) {
                FADebug.Log(FADebug.LogLevel.INFO, "Instantiating Primary Weapon [" + loadout.primaryWeapon.name + "]");
                loadout.primaryWeapon = GameObject.Instantiate(loadout.primaryWeapon, transform);
            }
        }

        if (loadout.secondaryWeapon) {
            if (!loadout.secondaryWeapon.isActiveAndEnabled) {
                FADebug.Log(FADebug.LogLevel.INFO, "Instantiating Secondary Weapon [" + loadout.secondaryWeapon.name + "]");
                loadout.secondaryWeapon = GameObject.Instantiate(loadout.secondaryWeapon, transform);
            }
        }

        if (loadout.tertiaryWeapon) {
            if (!loadout.tertiaryWeapon.isActiveAndEnabled) {
                FADebug.Log(FADebug.LogLevel.INFO, "Instantiating Back Weapon [" + loadout.tertiaryWeapon.name + "]");
                loadout.tertiaryWeapon = GameObject.Instantiate(loadout.tertiaryWeapon, transform);
            }
        }

        if (loadout.tacticalThrowable) {
            if (!loadout.tacticalThrowable.isActiveAndEnabled) {
                FADebug.Log(FADebug.LogLevel.INFO, "Instantiating Tactical Equipment [" + loadout.tacticalThrowable.name + "]");
                loadout.tacticalThrowable = GameObject.Instantiate(loadout.tacticalThrowable, transform);
            }
        }

        if (loadout.lethalThrowable) {
            if (!loadout.lethalThrowable.isActiveAndEnabled) {
                FADebug.Log(FADebug.LogLevel.INFO, "Instantiating LethalEquipment [" + loadout.lethalThrowable.name + "]");
                loadout.lethalThrowable = GameObject.Instantiate(loadout.lethalThrowable, transform);
            }
        }
    }

    private void UnequipActive() {
        if (activeEquipmentSlot == EquipmentSlot.None) { return; }

        switch (activeEquipmentSlot) {
            case EquipmentSlot.PrimaryWeapon:
                equipableInventory.EquipToPrimaryHolster(loadout.primaryWeapon);
                break;
            case EquipmentSlot.SecondaryWeapon:
                equipableInventory.EquipToSecondaryHolster(loadout.secondaryWeapon);
                break;
            case EquipmentSlot.TertiaryWeapon:
                equipableInventory.EquipToBackHolster(loadout.tertiaryWeapon);
                break;
            case EquipmentSlot.LethalThrowable:
                equipableInventory.EquipToLethalHolster(loadout.lethalThrowable);
                break;
            case EquipmentSlot.TacticalThrowable:
                equipableInventory.EquipToTacticalHolster(loadout.tacticalThrowable);
                break;
            case EquipmentSlot.None:
            default:
                break;
        }

        weaponController.activeWeapons.Clear();
        activeEquipmentSlot = EquipmentSlot.None;
    }
    private void EquipAndArm(EquipmentSlot equipmentSlot) {
        Weapon weapon = loadout.GetWeaponFromEquipmentSlot(equipmentSlot);

        if (weapon) {
            equipableInventory.EquipToPrimaryWeaponHand(weapon);
            weaponController.activeWeapons.Add(weapon);
            activeEquipmentSlot = equipmentSlot;

            weapon.Equip();
        }
    }
}
