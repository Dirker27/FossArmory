using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterfaceController : MonoBehaviour
{
    public UIConsoleTextController consoleText;
    public UIPawnTextController pawnText;
    public UIWeaponTextController weaponText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddConsoleText(string key, string value) {
        if (consoleText) {
            consoleText.AddValueToConsole(key, value);
        }
    }

    public void AddConsoleVector(string key, Vector3 value) { 
        if (consoleText) {
            consoleText.AddVectorToConsole(key, value);
        }
    }

    public void AddConsoleLogMessage(string logMessage) {
        if (consoleText) {
            consoleText.LogMessage(logMessage);
        }
    }
}
