using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        if (!target)
        {
            Debug.LogError("No Player Found - Cannot Dock Camera.");
        }       
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Do this with Math
        //Vector3 correctedOffset = -target.transform.forward * offset;

        Vector3 targetPosition = target.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.5f);
    }
}
