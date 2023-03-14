using UnityEngine;
using System.Collections;

public class BallisticsAim : MonoBehaviour {

    public BallisticSolver solver;

    private int layerMask = 1 << 8; // 8 == Target Elligible (only detect this layer)

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, float.PositiveInfinity, layerMask))
        {
            solver.target = hitInfo.point;
        }
    }
}
