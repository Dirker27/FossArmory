using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public CameraAim targetingCamera;
    public Projectile projectileTemplate;

    public Transform launchPoint;
    public Transform projectileParent;

    public float launchForce = 1.0f; // Newtons [N]
    public float launchVelocity = 1.0f; // Meters / Second [m/s]

    // Start is called before the first frame update
    void Start()
    {
        if (launchPoint == null)
        {
            launchPoint = transform;
        }

        if (!targetingCamera)
        {
            Debug.LogError("MISSING REQUIRED COMPONENT: Targeting Camera");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Fire when Ready
        // TODO: Use a common input management component
        if (Input.GetMouseButtonDown(0))
        {
            Launch();
        }
    }

    public void Launch()
    {
        // Launch at Target
        Ray aimRay = targetingCamera.GetAimingRay();
        Quaternion q = Quaternion.LookRotation(aimRay.direction, transform.up);

        Projectile projectile = GameObject.Instantiate(projectileTemplate, transform.position, q);
        projectile.transform.parent = projectileParent;

        /*Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb)
        {
            // TODO: Perform during FixedUpdate() to use physics thread
            Vector3 forceVector = transform.forward * launchForce;
            rb.AddForce(forceVector, ForceMode.Impulse);
        }*/

        Debug.DrawRay(aimRay.origin, (aimRay.direction) * 5, Color.green, 0.5f);
    }
}
