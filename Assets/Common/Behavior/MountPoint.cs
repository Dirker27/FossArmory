using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Provides a location for Mountable objects to bind their location/rotations to.
 */
public class MountPoint : MonoBehaviour
{
    public Vector3 GetCurrentPosition()
    {
        return transform.position;
    }

    public Quaternion GetCurrentRotation()
    {
        return transform.rotation;
    }
}
