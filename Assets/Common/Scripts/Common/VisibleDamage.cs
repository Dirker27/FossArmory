using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleDamage : MonoBehaviour
{
    // Bullet Hole Templates
    public GameObject projectileDamageTemplate;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyProjectileDamage(Collision collision)
    {
        GameObject damageTile = GameObject.Instantiate(projectileDamageTemplate, collision.transform.position, collision.transform.rotation, transform);;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile)
        {
            ApplyProjectileDamage(collision);
        }
    }
}
