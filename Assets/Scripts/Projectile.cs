using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;

    public bool useLaunchVelocity = true;
    public float initialVelocity = 1f; // Meters / Second [m/s]

    private bool hasFired = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!rb)
        {
            Debug.LogError("Missing Required Component: Rigidbody");
        }
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.cyan);
    }

    // Called on fixed interval - use for physics
    void FixedUpdate()
    {
        if (!hasFired)
        {
            Rigidbody rb = GetComponent<Rigidbody>();

            rb.velocity = transform.forward * initialVelocity;

            hasFired = true;
        }
    }

    /**
     * KE == 1/2 m * v^2
     * 1[J] == 1[N] / 1[m]
     */
    public float GetKineticEnergyJoules()
    {
        if (!rb) { return 0f; }

        float mass = 1;
        float velocity = initialVelocity;

        return (mass * (velocity * velocity)) / 2;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("IMPACT: " 
            + GetKineticEnergyJoules() + "[J] | "
            + rb.velocity + "[m/s], "
            + rb.mass + "[kg]");
    }
}
