using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * Manages active and stored equipment for a given pawn
 */
public class EquipmentController : MonoBehaviour
{
    private EquipableInventory equipableInventory;

    public bool receivePlayerInput = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!TryGetComponent<EquipableInventory>(out equipableInventory)) {
            Debug.LogError("Missing Required Component: Equipable Inventory");
        }
    }

    public void WeaponSwap() {
        Debug.Log("Swapping Weapons...");

        Weapon currentWeapon = equipableInventory.currentWeapon;
        equipableInventory.EquipWeapon(equipableInventory.holsteredWeapon);
        equipableInventory.HolsterWeapon(currentWeapon);
    }

    public void EquipmentSwap() {
        Debug.Log("Swapping Equipment...");
    }
}
