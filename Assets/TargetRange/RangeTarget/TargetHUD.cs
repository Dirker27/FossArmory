using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class TargetHUD : MonoBehaviour
{
    public Destructible destructibleHealth;

    public Text textTarget;

    // Update is called once per frame
    void Update()
    {
        if (!destructibleHealth || !textTarget) { return; }

        string text = destructibleHealth.lifetimeEnergyAbsorbed + " / " +
            destructibleHealth.totalDestructionEnergy;
        textTarget.text = text;
    }
}
