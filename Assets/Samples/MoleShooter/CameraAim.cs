using UnityEngine;
using System.Collections;

/**
 * Aiming module to be mounted to a camera to provide a point of aim.
 */
public class CameraAim : MonoBehaviour {

    private Camera cam;

	void Start()
    {
        cam = GetComponent<Camera>();
        if (cam == null) {
            Debug.LogError("No Camera Set! Will not be able to aim.");
        }
	}

    /**
     * Provides a Ray cast from current position to the cursor position.
     */
    public Ray GetAimingRay()
    {
        return cam.ScreenPointToRay(Input.mousePosition);
    }
}
