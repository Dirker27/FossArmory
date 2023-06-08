using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIConsoleTextController : MonoBehaviour
{
    private Text text;
    private PlayerController playerController;
    private string prefix = "\\> ";
    private string suffix = " |- ";

    void Start() {
        if (!TryGetComponent<Text>(out text)) {
            Debug.LogError("Missing Required Component: Text");
        }
    }
    // Update is called once per frame
    void Update() {
        text.text = prefix + "$init_newsfeed ...\n" 
            + suffix + "...\n" 
            + suffix + "...\n";
    }
}
