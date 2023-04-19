using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Provides a location for Mountable objects to bind their location/rotations to.
 */
public class MountPoint : MonoBehaviour
{
    public bool drawGizmo = true;
    public Vector3 radius = new Vector3(0.05f, 0.05f, 0.05f);

    public Vector3 GetCurrentPosition()
    {
        return transform.position;
    }

    public Quaternion GetCurrentRotation()
    {
        return transform.rotation;
    }

    private void OnDrawGizmos() {
        if (!drawGizmo) { return; }
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius.x);
    }
}
