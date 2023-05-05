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
        inputDelegate = new InputDelegate(inputActions);

        SetActivePawnToPlayer();
        if (activePawn) {
            PosessPawn(activePawn);
        } else {
            Debug.Log("No initial player pawn set.");
        }
        PosessPawn(activePawn);

        // TODO: Move to dedicated Pawn Posession Controller
        inputActions.Player.Posess.performed += ctx => TogglePosess();
    }

    public static FA_InputActions GetInputActions() {
        return inputActions;
    }

    public void PosessPawn(Pawn pawn) {
        activePawn = pawn;
        inputDelegate.BindInputToPawn(activePawn);
    }

    public void ReleaseActivePawn() {
        inputDelegate.Release();
        activePawn.Release();

        activePawn = null;
    }

    void TogglePosess() {
        if (activePawn) {
            ReleaseActivePawn();
        } else {
            SetActivePawnToPlayer();
            PosessPawn(activePawn);
        }
    }

    private void SetActivePawnToPlayer() {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject) {
            Pawn pawn = playerObject.GetComponent<Pawn>();
            if (pawn) {
                activePawn = pawn;
            }
        }
    }
}
