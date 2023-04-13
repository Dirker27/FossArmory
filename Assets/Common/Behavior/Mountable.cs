using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Binds a given object's transform to a provided mount point if set.
 */
public class Mountable : MonoBehaviour
{
    public MountPoint mountTarget;
    public Vector3 mountOffset = Vector3.zero;
    public bool captureOffsetOnStart = false;

    private void Start()
    {
        if (captureOffsetOnStart && mountTarget)
        {
            mountOffset = transform.position - mountTarget.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mountTarget)
        {
            transform.position = mountTarget.GetCurrentPosition() + mountOffset;
        }
    }
}
