using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWeaponTextController : MonoBehaviour
{
    private Text text;
    private PlayerController playerController;
    private string prefix = "WEAPON: ";

    void Start() {
        playerController = GameManager.GetPlayerController();

        if (!TryGetComponent<Text>(out text)) {
            Debug.LogError("Missing Required Component: Text");
        }
    }
    // Update is called once per frame
    void Update() {
        string weaponName = "NONE";
        WeaponController weaponController = null;
        Pawn pawn = playerController.activePawn;
        if (pawn && pawn.TryGetComponent<WeaponController>(out weaponController)) {
            foreach (Weapon weapon in weaponController.activeWeapons) {
                weaponName = weapon.name;
            }
        }

        text.text = prefix + " [" + weaponName + "]";
    }
}
