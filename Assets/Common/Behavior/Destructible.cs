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

    //~ PRIVATE STATE ------------------------------------=
    //
    private bool _hasDestructed = false;
    private bool _performDestructPhysics = false;
    private bool _performDestroy = false;
    private GameObject _spawnedDebris = null;
    private Vector3 _lastHitLocation = Vector3.zero;

    //~ ========================================================= ~//
    //  DESTRUCTION LOGIC
    //~ ========================================================= ~//

    public void Destruct() {
        if (_hasDestructed) { return; }
        _hasDestructed = true;

        /*foreach (Collider collider in GetComponents<Collider>()) {
            collider.enabled = false;
        }*/

        foreach (GameObject go in debrisTemplate) {
            _spawnedDebris = GameObject.Instantiate(go, transform.position, transform.rotation);
            _spawnedDebris.transform.parent = debrisParent;
        }

        _performDestructPhysics = true;
    }

    void FixedUpdate() {
        if (!_performDestructPhysics) { return; }
        _performDestructPhysics = false;

        foreach (Rigidbody rb in _spawnedDebris.GetComponentsInChildren<Rigidbody>()) {
            rb.AddExplosionForce(destructionForce, _lastHitLocation, 10, 10, ForceMode.Impulse);
        }

        _performDestroy = true;
    }

    void Update() {
        if (_performDestroy) {
            GameObject.Destroy(this.gameObject);
        }
    }

    //~ ========================================================= ~//
    //  COLLISION / HEALTH LOGIC
    //~ ========================================================= ~//

    private void OnCollisionEnter(Collision collision)
    {
        if (!physicsEnabled) { return; }

        if (collision.rigidbody) {
            _lastHitLocation = collision.gameObject.transform.position; //collision.GetContact(0).point;
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

    /**
     * KE == 1/2 m * v^2
     * 1[J] == 1[N] / 1[m]
     */
    private static float GetKineticEnergyJoules(Rigidbody rigidbody) {
        float v2 = rigidbody.velocity.magnitude * rigidbody.velocity.magnitude;
        return (rigidbody.mass * v2) / 2;
    }
}
