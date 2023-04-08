using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovementController : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset = Vector3.zero;
    public Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.3f;

    private FA_InputActions inputActions;
    private Vector2 rotate;

    private Vector3 cameraRotation;

    void Start()
    {
        inputActions = GameManager.GetInputActions();

        // Movement Rotation - use captured vector if input axis is set, zero if not
        inputActions.Player.Look.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        inputActions.Player.Look.canceled += ctx => rotate = Vector2.zero;

        cameraRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        //- Rotate Towards Mouse Direction ------------------------=
        //
        cameraRotation = new Vector3(cameraRotation.x + rotate.y, cameraRotation.y + rotate.x, cameraRotation.z);
        transform.eulerAngles = cameraRotation;

        //- Move Towards Target Object ----------------------------=
        //
        if (target)
        {
            Vector3 targetPosition = target.transform.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
