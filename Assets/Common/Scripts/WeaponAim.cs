using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    public bool isTargetLockEnabled = false;

    public TargetProvider targetProvider = null;
    public Vector3 targetRotation = Vector3.zero;

    public Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.1f;

    void Start()
    {
        
    }

    void Update()
    {
        if (targetProvider == null) { return; }

        if (!targetProvider.IsTargetingLocationValid())
        {
            targetRotation = transform.forward;
        }

        targetRotation = targetProvider.GetTargetingRay().direction;
        Debug.Log("Target Weapon Rotation: " + targetRotation);

        //Vector3 rotation = Vector3.SmoothDamp(transform.rotation.eulerAngles, targetRotation, ref velocity, smoothTime);
        //transform.rotation.SetLookRotation(targetRotation);

        if (targetProvider.IsTargetingLocationValid())
        {
            transform.LookAt(targetProvider.GetTargetingLocation(), Vector3.up);
        }
    }

    public void SetTargetLock(bool targetLockEnabled)
    {
        this.isTargetLockEnabled = targetLockEnabled;
    }
}
