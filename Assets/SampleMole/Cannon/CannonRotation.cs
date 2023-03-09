using UnityEngine;
using System.Collections;

public class CannonRotation : MonoBehaviour {

    public CameraAim targetingCamera;
	
	// Update is called once per frame
	void Update () {
        Ray target = targetingCamera.GetAimingRay();
        Quaternion q = Quaternion.LookRotation(target.direction, transform.up);

        transform.rotation = q;
	}
}
