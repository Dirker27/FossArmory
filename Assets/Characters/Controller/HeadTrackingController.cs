using UnityEngine;
using System.Collections;
using System.Drawing;
using System;

public class HeadTrackingController : MonoBehaviour {

	public TargetProvider targetProvider;
	public float lookSpeed = 1f;
	
	void Update () {
		if (targetProvider) {
            LookTowardsTarget();
        }
    }

	void LookTowardsTarget() {
        // Use raw direction if no world-space point is available.
        Vector3 targetDirection = targetProvider.GetTargetingRay().direction; // unit
        if (targetProvider.IsTargetingLocationValid()) {
            targetDirection = targetProvider.GetTargetingLocation() - transform.position; 
        }

        Quaternion toRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, lookSpeed * Time.deltaTime);
    }
}
