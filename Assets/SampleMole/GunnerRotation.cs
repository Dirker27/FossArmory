using UnityEngine;
using System.Collections;

/**
 * Rotates a "Gunner" Actor to follow the aim direction of the Targeting Camera.
 */
public class GunnerRotation : MonoBehaviour {

    public float rotationSpeed = 10.0f;
    public CameraAim targetingCamera;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		if (targetingCamera)
		{
			Ray target = targetingCamera.GetAimingRay();
			Quaternion lookAt = Quaternion.LookRotation(target.direction, Vector3.up);

			transform.rotation = Quaternion.Lerp(transform.rotation, lookAt,
				0.1f * rotationSpeed * Time.deltaTime);
		}
	}
}
