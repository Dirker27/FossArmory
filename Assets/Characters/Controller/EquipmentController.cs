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

        BindInput(GameManager.GetInputActions());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BindInput(FA_InputActions inputActions) {

        inputActions.Player.WeaponSelect.performed += ctx => WeaponSwap();
        inputActions.Player.EquipmentSelect.performed += ctx => EquipmentSwap();
    }

    private void WeaponSwap() {
        Debug.Log("Swapping Weapons...");

        Weapon currentWeapon = equipableInventory.currentWeapon;
        equipableInventory.EquipWeapon(equipableInventory.holsteredWeapon);
        equipableInventory.HolsterWeapon(currentWeapon);
    }

    private void EquipmentSwap() {

    }
}
