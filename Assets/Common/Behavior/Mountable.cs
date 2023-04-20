using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Binds a given object's transform to a provided mount point if set.
 */
public class Mountable : MonoBehaviour
{
    public MountPoint mountPoint;
    public Vector3 mountOffset = Vector3.zero;

    public bool applyRotation = false;
    public bool captureOffsetOnStart = false;

    void Start()
    {
        if (captureOffsetOnStart && mountPoint)
        {
            mountOffset = transform.position - mountPoint.transform.position;
        }
    }

    void Update()
    {
        if (mountPoint)
        {
            transform.position = mountPoint.GetCurrentPosition() + mountOffset;

            if (applyRotation) {
                transform.rotation = mountPoint.transform.rotation;
            }
        }
    }

    public void Mount(MountPoint mountPoint) {
        Mount(mountPoint, Vector3.zero);
    }
    public void Mount(MountPoint mountPoint, Vector3 mountOffset) {
        this.mountPoint = mountPoint;
        this.mountOffset = mountOffset;
    }

    private void OnDrawGizmos() {
        if (mountPoint) {
            Gizmos.DrawLine(transform.position, mountPoint.transform.position);
        }
    }
}
