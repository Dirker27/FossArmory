using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timeScale = 1f;

    // Statically accessed to enforce that there should only be one
    //   of these in each scene.
    //
    // Initialized/linked during Awake() in order to provide to downstream
    //   consumers by the time they can call Start()
    private static GameObject mainCamera;
    private static GarbageCollector garbageCollector;
    private static PlayerController playerController;
    private static UserInterfaceController userInterfaceController;

    private void Awake() {
        garbageCollector = GetComponentInChildren<GarbageCollector>();
        if (!garbageCollector) {
            FADebug.Log(FADebug.LogLevel.ERROR, "MISSING REQUIRED COMPONENT: Garbage Collector");
        }

        if (!TryGetComponent<PlayerController>(out playerController)) {
            FADebug.Log(FADebug.LogLevel.ERROR, "MISSING REQUIRED COMPONENT: Player Controller");
        }

        if (!TryGetComponent<UserInterfaceController>(out userInterfaceController)) {
            FADebug.Log(FADebug.LogLevel.ERROR, "MISSING REQUIRED COMPONENT: UI Controller");
        }

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        if (!mainCamera) {
            FADebug.Log(FADebug.LogLevel.ERROR, "MISSING REQUIRED COMPONENT: Main Camera");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        FADebug.SetLogLevel(FADebug.LogLevel.DEBUG);
    }

    void Update()
    {
        Time.timeScale = timeScale;
    }

    [Obsolete("Use a PlayerController instead.")]
    public static FA_InputActions GetInputActions()
    {
        return PlayerController.GetInputActions() ;
    }

    public static PlayerController GetPlayerController() {
        return playerController;
    }

    public static UserInterfaceController GetUserInterfaceController() {
        return userInterfaceController;
    }

    public static GarbageCollector GetGarbageCollector() {
        return garbageCollector;
    }

    public static GameObject GetMainCamera() {
        return mainCamera;
    }
}
