using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float runSpeed = 10f;
    public float turnSpeed = 1f;
    public float jumpTime = 1f;
    public float jumpSpeed = 9.8f;

    public FA_InputActions inputActions;
    private Vector2 move;
    private Vector2 rotate;
    private float jumpStarted;
    private float movementSpeed;

    public Camera playerCamera;
    private Vector3 cameraRotation;

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void Awake()
    {
        //- Bind Input Events ----------------------------=
        //
        inputActions = new FA_InputActions();
        //
        // Jump
        inputActions.Player.Jump.performed += ctx => Jump();
        //
        // Movement Speed - use runSpeed if button pressed
        inputActions.Player.Run.performed += ctx => movementSpeed = runSpeed;
        inputActions.Player.Run.canceled += ctx => movementSpeed = walkSpeed;
        //
        // Movement Direction - use captured vector if input axis is set, zero if not
        inputActions.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => move = Vector2.zero;
        //
        // Movement Rotation - use captured vector if input axis is set, zero if not
        inputActions.Player.Look.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        inputActions.Player.Look.canceled += ctx => rotate = Vector2.zero;
    }

    void Start()
    {
        movementSpeed = walkSpeed;
        cameraRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        jumpStarted = -1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        cameraRotation = new Vector3(cameraRotation.x + rotate.y, cameraRotation.y + rotate.x, cameraRotation.z);

        //- Rotate Towards Camera ------------------------=
        //
        playerCamera.transform.eulerAngles = cameraRotation;
        transform.eulerAngles = new Vector3(transform.rotation.x, cameraRotation.y, transform.rotation.z);

        //- Move Transform -------------------------------=
        //
        Vector2 applyMove = Vector2.ClampMagnitude(move, 1);
        transform.Translate(Vector3.right * Time.deltaTime * applyMove.x * movementSpeed, Space.Self);
        transform.Translate(Vector3.forward * Time.deltaTime * applyMove.y * movementSpeed, Space.Self);

        //- Apply Jump -----------------------------------=
        //
        // Going Up
        if (jumpStarted + (jumpTime / 2) > Time.time)
        {
            transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime, Space.Self);
        }
        // Going Down
        else if (jumpStarted + jumpTime > Time.time)
        {
            transform.Translate(Vector3.up * -jumpSpeed * Time.deltaTime, Space.Self);
        }
    }

    private void Jump()
    {
        if (jumpStarted + jumpTime < Time.time)
        {
            jumpStarted = Time.time;
        }
    }
}
