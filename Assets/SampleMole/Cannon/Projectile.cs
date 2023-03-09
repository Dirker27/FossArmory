using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float launchForce = 10.0f;
    public float duration = 10.0f;

    private bool hasFired = false;
    private float lifeTime = 0f;

    void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > duration)
        {
            GameObject.Destroy(this);
        }
    }

    // Called on fixed interval - use for physics
    void FixedUpdate() 
    {
        if (!hasFired)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            //rb.AddForce(new Vector3(0, 0, launchForce), ForceMode.Impulse);
            rb.AddForce(transform.forward, ForceMode.Impulse);

            hasFired = true;
        }

        Debug.DrawRay(transform.position, transform.forward, Color.cyan);
    }
}
