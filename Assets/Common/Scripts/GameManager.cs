using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timeScale = 1f;

    public GarbageCollector garbageCollector;

    private static FA_InputActions inputActions;

    void Awake()
    {
        inputActions = new FA_InputActions();
    }

    void OnEnable()
    {
        inputActions.Player.Enable();
    }

    void OnDisable()
    {
        inputActions.Player.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (! GetComponentInChildren<GarbageCollector>())
        {
            Debug.LogError("MISSING REQUIRED COMPONENT: Garbage Collector");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
    }

    public static FA_InputActions GetInputActions()
    {
        return inputActions;
    }
}
