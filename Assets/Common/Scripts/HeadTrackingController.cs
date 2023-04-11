using UnityEngine;
using System.Collections;

public class HeadTrackingController : MonoBehaviour {

	public TargetProvider targetProvider;
	
	// Update is called once per frame
	void Update () {
		if (targetProvider && targetProvider.IsTargetingLocationValid()) {
			transform.LookAt(targetProvider.GetTargetingLocation(), Vector3.up);
		}
    }
}
