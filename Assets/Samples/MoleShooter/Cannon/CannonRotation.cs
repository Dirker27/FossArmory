using UnityEngine;
using System.Collections;

/**
 * Orients a Weapon to point at a targeting camera's point-of-aim.
 */
public class CannonRotation : MonoBehaviour {

    public CameraAim targetingCamera;
	
	// Update is called once per frame
	void Update () {
        if (targetingCamera)
        {
            Ray target = targetingCamera.GetAimingRay();
            Quaternion q = Quaternion.LookRotation(target.direction, transform.up);

            transform.rotation = q;
        }
	}
}
