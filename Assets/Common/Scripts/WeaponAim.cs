using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    public bool isTargetLockEnabled = false;
    public Vector3 targetRotation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTargetLockEnabled) { return; }

        //Vector3 rotation = Vector3.Slerp(targetRotation, transform.rotation.eulerAngles, Time.deltaTime);

        //transform.rotation.SetLookRotation(rotation);
    }

    public void SetTargetLock(bool targetLockEnabled)
    {
        this.isTargetLockEnabled = targetLockEnabled;
    }
}
