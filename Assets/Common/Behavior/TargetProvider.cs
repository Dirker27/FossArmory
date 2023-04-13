using System.Collections;
using UnityEngine;

public abstract class TargetProvider : MonoBehaviour
{
    // Gets the exact world coordinates that are being targeted
    public abstract Vector3 GetTargetingLocation();

    // Targeted direction in world coordinates
    public abstract Vector3 GetTargetingDirection();

    // Gets the ray used to identify current target.
    //   Should NOT be used for getting direction (will be relative to caster)
    public abstract Ray GetTargetingRay();

    // If a valid location is currently being targeted (not just staring out into space)
    public abstract bool IsTargetingLocationValid();
}