using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public List<GameObject> debrisTemplate = new List<GameObject>();
    public Transform debrisParent;
    public float destructionForce = 1f; // Newtons [N]

    // minimum energy to receive damage
    public float minimumDestructionThreshold = 1f; // Joules [J]

    // total energy needed for destruction
    public float totalDestructionEnergy = 100f; // Joules [J]

    // total energy received over lifetime
    public float lifetimeEnergyAbsorbed = 0f; // Joules [J]

    // whether we want to receive damage from the world's physics system
    public bool physicsEnabled = true;

    private bool hasDestructed = false;

    /**
     * START
     */
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!physicsEnabled) { return; }

        if (collision.rigidbody) {
            float impactEnergy = GetKineticEnergyJoules(collision.rigidbody);
            /*Debug.Log("IMPACT: "
                + impactEnergy + "[J] | "
                + collision.rigidbody.velocity + "[m/s], "
                + collision.rigidbody.mass + "[kg]");*/
            ApplyEnergyJoules(impactEnergy);
        }
    }

    public void ApplyEnergyJoules(float energy)
    {
        if (energy > minimumDestructionThreshold)
        {
            lifetimeEnergyAbsorbed += energy;
        }

        if (lifetimeEnergyAbsorbed > totalDestructionEnergy)
        {
            Destruct();
        }
    }

    public void Destruct()
    {
        if (hasDestructed) { return; }
        hasDestructed = true;

        foreach (GameObject go in debrisTemplate)
        {
            GameObject debris = GameObject.Instantiate(go, transform);
            debris.transform.parent = debrisParent;
            
            Rigidbody rb = debris.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(destructionForce, transform.position, 10, 10, ForceMode.Impulse);
            }
        }

        GameObject.Destroy(this.gameObject);
    }

    /**
     * KE == 1/2 m * v^2
     * 1[J] == 1[N] / 1[m]
     */
    private float GetKineticEnergyJoules(Rigidbody rigidbody)
    {
        float v2 = rigidbody.velocity.magnitude * rigidbody.velocity.magnitude;
        return (rigidbody.mass * v2) / 2;
    }
}
