using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour
{
    public float durationSeconds = 10;

    private float timeAlive = 0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;

        if (timeAlive > durationSeconds)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
