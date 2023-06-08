using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPawnTextController : MonoBehaviour
{
    private Text text;
    private PlayerController playerController;
    private string prefix = "PAWN: ";

    void Start() {
        playerController = GameManager.GetPlayerController();
        
        if (!TryGetComponent<Text>(out text)) {
            Debug.LogError("Missing Required Component: Text");
        }
    }
    // Update is called once per frame
    void Update()
    {
        string actorName = "NONE";
        if (playerController.activePawn) {
            actorName = playerController.activePawn.name;
        }

        text.text = prefix + " [" + actorName + "]";
    }
}
