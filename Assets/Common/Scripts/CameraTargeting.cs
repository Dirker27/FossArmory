using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

/**
 * Aiming module to be mounted to a camera to provide a point of aim.
 */
public class CameraTargeting : MonoBehaviour {

    private Camera cam;

    private TargetPoint targetPoint;

    private static int LAYER_MASK = 1 << 8;

	void Start()
    {
        cam = GetComponent<Camera>();
        if (!cam) {
            Debug.LogError("No Camera Set! Will not be able to aim.");
        }

        targetPoint = GetComponentInChildren<TargetPoint>();
        if(!targetPoint) { Debug.LogError("No TargetPoint Set!");  }
	}

    void Update()
    {
        Vector3 targetPosition = GetLookPointPosition();
        targetPoint.SetTargetPosition(targetPosition);
    }

    private Vector3 GetLookPointPosition()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, float.PositiveInfinity))
        {
            return hitInfo.point;
        }
        return Vector3.zero;
    }

    /**
     * Provides a Ray cast from current position to the cursor position.
     */
    public Ray GetTargetingRay()
    {
        return cam.ScreenPointToRay(Input.mousePosition);
    }
}
