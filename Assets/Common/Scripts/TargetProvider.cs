using System.Collections;
using UnityEngine;

public abstract class TargetProvider : MonoBehaviour
{
    // Gets the exact world coordinates that are being targeted
    public abstract Vector3 GetLookPointPosition();

    // Gets the current direction to target.
    public abstract Ray GetTargetingRay();

    // If a valid location is currently being targeted (not just staring out into space)
    public abstract bool IsTargeingLocation();
}