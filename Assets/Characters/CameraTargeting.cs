using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

/**
 * Aiming module to be mounted to a camera to provide a point of aim.
 * 
 * ***** MOUSE-ONLY *****
 * TODO: Support Gamepad Targeting
 */
public class CameraTargeting : TargetProvider {

    private Camera cam;

    // Child 
    private TargetPoint targetPoint;

    // TOOD: Define Layers for UI + Terget-able objects.
    //private static int LAYER_MASK = 1 << 8;

    // cached current content data
    private Ray _targetingRay;
    private Vector3 _targetingPosition;
    private bool _targetPositionValid;

	void Start()
    {
        //- REQUIRE---------------------------------------=
        //
        // Camera
        cam = GetComponent<Camera>();
        if (!cam) { Debug.LogError("Missing Required Component: Camera"); }
        // Child: Target Point
        targetPoint = GetComponentInChildren<TargetPoint>();
        if(!targetPoint) { Debug.LogError("No TargetPoint Set!");  }

        //- CACHE ----------------------------------------=
        _targetingPosition = Vector3.zero;
        _targetingRay = new Ray();
        _targetPositionValid = false;
	}

    void Update() {
        Target();

        Vector3 targetPosition = GetTargetingLocation();
        targetPoint.SetTargetPosition(targetPosition);
    }

    private void Target() {
        _targetingRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(_targetingRay, out hitInfo, float.PositiveInfinity))
        {
            _targetingPosition = hitInfo.point;
            _targetPositionValid = true;
        }
        else
        {
            _targetPositionValid = false;
        }
    }

    public override bool IsTargetingLocationValid() {
        return _targetPositionValid;
    }

    public override Vector3 GetTargetingLocation() {
        return _targetingPosition;
    }

    public override Vector3 GetTargetingDirection() {
        return gameObject.transform.rotation.eulerAngles;
    }

    public override Ray GetTargetingRay() {
        return _targetingRay;
    }
}
