using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Destroys all GameObjects that cross the threshold of our collider.
 * 
 * Used to contain or clean up assets that enter or leave a given container object.
 */
public class KillBox : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Destroy(collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject.Destroy(collision.gameObject);
    }
}
