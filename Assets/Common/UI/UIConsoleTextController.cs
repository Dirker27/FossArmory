using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIConsoleTextController : MonoBehaviour
{
    public int LOG_MESSAGE_LIMIT = 10;
    public bool debugFeedEnabled = true;
    public bool logFeedEnabled = true;

    private Text text;
    private string prefix = "\\> ";
    private string suffix = " |- ";

    private Dictionary<string, string> stringValues = new Dictionary<string, string>();
    private Dictionary<string, Vector3> vectorValues = new Dictionary<string, Vector3>();
    private Queue<string> logMessageQueue = new Queue<string>();

    void Start() {
        if (!TryGetComponent<Text>(out text)) {
            FADebug.Log(FADebug.LogLevel.ERROR, "Missing Required Component: Text");
        }

        logMessageQueue.Enqueue("NewsFeed Initialized.");
    }
    // Update is called once per frame
    void Update() {
        if (debugFeedEnabled) {
            text.text = "= DEBUG ==========================\n";

            foreach (string key in vectorValues.Keys) {
                text.text += VectorPairToString(key);
            }
            foreach (string key in stringValues.Keys) {
                text.text += StringPairToString(key);
            }
        }

        if (logFeedEnabled) {

            text.text += "= LOG FEED =======================\n";

            foreach (string message in logMessageQueue) {
                text.text += string.Format("{0}{1}\n", prefix, message);
            }
        }
    }

    public void LogMessage(string message) {
        logMessageQueue.Enqueue(message);

        if (logMessageQueue.Count > LOG_MESSAGE_LIMIT) {
            logMessageQueue.Dequeue();
        }
    }

    public void AddValueToConsole(string key, string value) {
        if (stringValues.ContainsKey(key)) {
            stringValues[key] = value;
        } else {
            stringValues.Add(key, value);
        }
    }
    public void AddVectorToConsole(string key, Vector3 value) {
        if (vectorValues.ContainsKey(key)) {
            vectorValues[key] = value;
        }
        else {
            vectorValues.Add(key, value);
        }
    }

    private string StringPairToString(string key) {
        return string.Format("{1}{2}:\n{3}{4}\n", prefix, key, suffix, stringValues[key]);
    }

    private string VectorPairToString(string key) {
        return string.Format("{0}{1}:\n{2}[{3}, {4}, {5}]\n",
            prefix, key,
            suffix, vectorValues[key].x, vectorValues[key].y, vectorValues[key].z);
    }
}
