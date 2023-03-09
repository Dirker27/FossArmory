using UnityEngine;
using System.Collections;

public class CameraAim : MonoBehaviour {

    private Camera camera;

	void Start()
    {
        camera = GetComponent<Camera>();
        if (camera == null) {
            Debug.LogError("No Camera Set! Will not be able to aim.");
        }
	}

    public Ray GetAimingRay()
    {
        return camera.ScreenPointToRay(Input.mousePosition);
    }
}
