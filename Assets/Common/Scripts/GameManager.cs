using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timeScale = 1f;

    public GarbageCollector garbageCollector;

    // Start is called before the first frame update
    void Start()
    {
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
}
