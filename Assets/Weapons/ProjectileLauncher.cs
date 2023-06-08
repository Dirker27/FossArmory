using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : Weapon
{
    public Projectile projectileTemplate;
    public Animator animator;

    public Transform launchPoint;
    public Transform projectileParent;

    public float launchForce = 1.0f; // Newtons [N]
    public float launchVelocity = 1.0f; // Meters / Second [m/s]

    // Start is called before the first frame update
    void Start()
    {
        if (! launchPoint)
        {
            launchPoint = transform;
        }
    }

    public override void Fire()
    {
        Projectile projectile = GameObject.Instantiate(projectileTemplate, launchPoint.position, launchPoint.transform.rotation);
        projectile.transform.parent = projectileParent;

        if (animator)
        {
            animator.SetBool("isFiring", true);
        }
    }

    public override void CancelFire() {
        if (animator) {
            animator.SetBool("isFiring", false);
        }
    }

    public override void Arm() {
        base.Arm();

        WeaponAim weaponAim = null;
        if (launchPoint.TryGetComponent<WeaponAim>(out weaponAim)) {
            Debug.Log(String.Format("[{0}] Enabling Weapon Aim.", name));
            weaponAim.SetTargetLockEnabled(true);
        }
    }

    public override void CancelArm() {
        base.CancelArm();
        
        WeaponAim weaponAim = null;
        if (launchPoint.TryGetComponent<WeaponAim>(out weaponAim)) {
            Debug.Log(String.Format("[{0}] Disabling Weapon Aim.", name));
            weaponAim.SetTargetLockEnabled(false);
        }
    }
}
