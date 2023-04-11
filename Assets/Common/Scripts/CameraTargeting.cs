using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

/**
 * Aiming module to be mounted to a camera to provide a point of aim.
 */
public class CameraTargeting : TargetProvider {

    private Camera cam;

    private TargetPoint targetPoint;

    // TOOD: Define Layers for UI + Terget-able objects.
    //private static int LAYER_MASK = 1 << 8;

    private Ray _targetingRay;
    private Vector3 _targetingPosition;
    private bool _targetPositionValid;

	void Start()
    {
        cam = GetComponent<Camera>();
        if (!cam) {
            Debug.LogError("No Camera Set! Will not be able to aim.");
        }

        targetPoint = GetComponentInChildren<TargetPoint>();
        if(!targetPoint) { Debug.LogError("No TargetPoint Set!");  }

        _targetingPosition = Vector3.zero;
        _targetingRay = new Ray();
        _targetPositionValid = false;
	}

    void Update()
    {
        Vector3 targetPosition = GetLookPointPosition();
        targetPoint.SetTargetPosition(targetPosition);

        Target();
    }

    private void Target()
    {
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

    public override bool IsTargeingLocation()
    {
        return _targetPositionValid;
    }

    public override Vector3 GetLookPointPosition()
    {
        return _targetingPosition;
    }

    public override Ray GetTargetingRay()
    {
        return _targetingRay;
    }
}
