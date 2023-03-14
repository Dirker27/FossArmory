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

    private void OnCollisionEnter(Collision collision)
    {
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile)
        {
            GameObject damageTile = GameObject.Instantiate(projectileDamageTemplate, collision.transform);
            damageTile.transform.parent = null;
        }
    }
}
