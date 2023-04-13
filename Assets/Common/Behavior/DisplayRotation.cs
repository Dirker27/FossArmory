using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRotation : MonoBehaviour
{
    public float rotationSpeed; // Degrees / Second
    public float bobSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = new Vector3(0, 1, 0) * rotationSpeed * Time.deltaTime;
        this.transform.Rotate(rotation);
    }
}
