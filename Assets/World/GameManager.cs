using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timeScale = 1f;

    private static GameObject mainCamera;
    private static GarbageCollector garbageCollector;
    private static PlayerController playerController;

    private void Awake() {
        garbageCollector = GetComponentInChildren<GarbageCollector>();
        if (!garbageCollector) {
            Debug.LogError("MISSING REQUIRED COMPONENT: Garbage Collector");
        }

        if (!TryGetComponent<PlayerController>(out playerController)) {
            Debug.LogError("MISSING REQUIRED COMPONENT: Player Controller");
        }

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        if (!mainCamera) {
            Debug.LogError("MISSING REQUIRED COMPONENT: Main Camera");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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

    public static GarbageCollector GetGarbageCollector() {
        return garbageCollector;
    }

    public static GameObject GetMainCamera() {
        return mainCamera;
    }
}
