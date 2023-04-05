using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public List<Weapon> activeWeapons = new List<Weapon>();

    private FA_InputActions inputActions;

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void Awake()
    {
        //- Bind Input Events ----------------------------=
        //
        inputActions = new FA_InputActions();
        //
        // Fire Weapon
        inputActions.Player.Fire.performed += ctx => Fire();
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void Fire()
    {
        foreach(Weapon weapon in activeWeapons)
        {
            Debug.Log("FIRING WEAPON: [" + weapon.name + "]");
            weapon.Fire();
        }
    }
}
