using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Animation cycleAnimation;

    public bool isArmed;

    public abstract void Fire();

    void Update()
    {
        
    }
}
