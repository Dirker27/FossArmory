using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float runSpeed = 10f;
    public float turnSpeed = 1f;
    public float jumpTime = 1f;
    public float jumpSpeed = 9.8f;

    private FA_InputActions inputActions;
    private Vector2 move;
    private Vector2 rotate;
    private float jumpStarted;
    private float movementSpeed;
    private Vector3 targetRotation;

    void Start()
    {
        movementSpeed = walkSpeed;
        jumpStarted = -1f;
        targetRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);

        //- Bind Input Events ----------------------------=
        //
        inputActions = GameManager.GetInputActions();
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

    // Update is called once per frame
    void Update()
    {
        //- Rotate Towards Camera ------------------------=
        //
        targetRotation = new Vector3(targetRotation.x /*+ rotate.y*/, targetRotation.y + rotate.x, transform.rotation.z);
        transform.eulerAngles = targetRotation;

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
