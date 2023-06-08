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

    void Start()
    {
        if (!targetProvider) {
            targetProvider = GameManager.GetMainCamera().GetComponent<TargetProvider>();
        }
    }

    void Update()
    {
        // default to parent-forward
        if (!isTargetLockEnabled) {
            transform.forward = transform.parent.forward;
        }

        if (!targetProvider.IsTargetingLocationValid())
        {
            targetRotation = transform.forward;
        }

        targetRotation = targetProvider.GetTargetingRay().direction;

        if (targetProvider.IsTargetingLocationValid())
        {
            transform.LookAt(targetProvider.GetTargetingLocation(), Vector3.up);
        }
    }

    public void SetTargetProvider(TargetProvider targetProvider) {
        this.targetProvider = targetProvider;
    }

    public void SetTargetLockEnabled(bool targetLockEnabled)
    {
        this.isTargetLockEnabled = targetLockEnabled;
    }
}
