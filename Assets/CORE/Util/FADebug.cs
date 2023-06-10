using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FADebug : MonoBehaviour
{
    public enum LogLevel {
        DEBUG=0, INFO=1, WARN=2, ERROR=3, FATAL=4
    }
    public static LogLevel filterLevel = LogLevel.DEBUG;

    private static UserInterfaceController userInterfaceController;

    // Start is called before the first frame update
    void Start()
    {
        userInterfaceController = GameManager.GetUserInterfaceController();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Log(string message) {
        Log(LogLevel.INFO, message);
    }

    public static void Log(LogLevel level, string message) {
        switch (level) {
            default:
            case LogLevel.DEBUG:
            case LogLevel.INFO:
                Debug.Log(message);
                break;
            case LogLevel.WARN:
                Debug.LogWarning(message);
                break;
            case LogLevel.ERROR:
            case LogLevel.FATAL:
                Debug.LogError(message);
                break;
        }

        if (userInterfaceController && level >= filterLevel) {
            userInterfaceController.AddConsoleLogMessage(message);
        }
    }

    public static void SetLogLevel(LogLevel level) {
        filterLevel = level;
    }
}
