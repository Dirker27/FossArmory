﻿using UnityEngine;
using System.Collections;

/**
 * Spawns a Projectile at the current location and orientation of the hosting Actor
 *  when input is given.
 */
public class CannonProjectileLauncher : MonoBehaviour {

    public GameObject projectileTemplate;
    public CameraAim targetingCamera;

	// Update is called once per frame
	void Update () {
        // Fire when Ready
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
	}

    public void Fire()
    {
        // Aim at Target
        Ray aimRay = targetingCamera.GetAimingRay();
        Quaternion q = Quaternion.LookRotation(aimRay.direction, transform.up);
        Debug.DrawRay(aimRay.origin, aimRay.direction, Color.green, 0.25f);

        GameObject.Instantiate(projectileTemplate, transform.position, q);
    }
}
