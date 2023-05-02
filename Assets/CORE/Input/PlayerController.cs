using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Pawn activePawn;

    private static FA_InputActions inputActions;
    private InputDelegate inputDelegate;
    private enum InputMode {
        UI,
        Gameplay
    }

    void Awake() {
        inputActions = new FA_InputActions();
    }

    void OnEnable() {
        inputActions.Player.Enable();
    }

    void OnDisable() {
        inputActions.Player.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        inputDelegate = new InputDelegate();
        inputDelegate.BindInputActions(inputActions);

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject) {
            Pawn pawn = playerObject.GetComponent<Pawn>();
            if (pawn) {
                activePawn = pawn;
            }
        }

        if (activePawn) {
            PosessPawn(activePawn);
        } else {
            Debug.Log("No Player Pawn Set!");
        }
    }

    public static FA_InputActions GetInputActions() {
        return inputActions;
    }

    void PosessPawn(Pawn pawn) {
        inputDelegate.BindInputToPawn(activePawn);
    }
}
