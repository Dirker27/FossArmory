using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A Generic Pawn Actor - A Character/Entity that can be controlled by a player or
 *   a similar posessing entity.
 *   
 * Can be "possessed" by players (local or remote) during runtime.
 */
public class Pawn : MonoBehaviour
{
    public InputSource inputSource;

    private EquipableInventory equipableInventory;

    public MovementController movementController;
    public WeaponController weaponController;
    public EquipmentController equipmentController;

    private void Awake() {
        if (!TryGetComponent<EquipableInventory>(out equipableInventory)) {
            FADebug.Log(FADebug.LogLevel.ERROR, "Missing Required Component: Equipable Inventory");
        }
        if (!TryGetComponent<MovementController>(out movementController)) {
            FADebug.Log(FADebug.LogLevel.ERROR, "Missing Required Component: Movement Controller");
        }
        if (!TryGetComponent<WeaponController>(out weaponController)) {
            FADebug.Log(FADebug.LogLevel.ERROR, "Missing Required Component: Weapon Controller");
        }
        if (!TryGetComponent<EquipmentController>(out equipmentController)) {
            FADebug.Log(FADebug.LogLevel.ERROR, "Missing Required Component: Equipment Controller");
        }
    }

    public void Posess() {
        inputSource = InputSource.Player;
    }

    public void Release() {
        inputSource = InputSource.Bot;
    }
}
