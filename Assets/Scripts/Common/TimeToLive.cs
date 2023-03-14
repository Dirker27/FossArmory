using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour
{
    public float durationMilliseconds = 1000;

    public float timeAlive = 0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;

        if (timeAlive > durationMilliseconds)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
