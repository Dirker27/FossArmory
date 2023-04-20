using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    public bool isTargetLockEnabled = false;

    public TargetProvider targetProvider = null;
    public Vector3 targetRotation = Vector3.zero;

    public float smoothTime = 0.1f;
    private Vector3 turnVelocity;

    void Start()
    {
        turnVelocity = Vector3.zero;
    }

    void Update()
    {
        if (targetProvider == null) { return; }

        if (!targetProvider.IsTargetingLocationValid())
        {
            targetRotation = transform.forward;
        }

        targetRotation = targetProvider.GetTargetingRay().direction;

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
