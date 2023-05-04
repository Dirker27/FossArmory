using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timeScale = 1f;

    public GarbageCollector garbageCollector;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        garbageCollector = GetComponentInChildren<GarbageCollector>();
        if (!garbageCollector)
        {
            Debug.LogError("MISSING REQUIRED COMPONENT: Garbage Collector");
        }

        if(!TryGetComponent<PlayerController>(out playerController)) {
            Debug.LogError("MISSING REQUIRED COMPONENT: Player Controller");
        }
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
}
