using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementAccelleration = 3f;
    public float movementDecelleration = 1f;
    public float walkingSpeed = 3f;
    public float runningSpeed = 7f;
    public float turningSpeed = 2f;
    public bool isRunning = false;

    protected Vector2 currentSpeed;
    protected float currentRotationSpeed;

    protected void ApplyMovement(Vector2 movement) {
        float decelleration = movementDecelleration * Time.deltaTime;

        float dx = (movement.x * movementAccelleration * Time.deltaTime) - decelleration;
        float dy = (movement.y * movementAccelleration * Time.deltaTime) - decelleration;

        float topSpeed = isRunning ? walkingSpeed : runningSpeed;
        //_currentSpeed = Vector2.ClampMagnitude(new Vector2(dx, dy), topSpeed);

        currentSpeed.x += dx;
        currentSpeed.y += dy;
        
        //if (dx > topSpeed) { dx = topSpeed; }
        //if (dy > topSpeed) { dy = topSpeed; }
        if (currentSpeed.x < 0) { currentSpeed.x = 0; }
        if (currentSpeed.y < 0) { currentSpeed.y = 0; }
         

        transform.Translate(new Vector3(currentSpeed.x, 0, currentSpeed.y) * Time.deltaTime);        
    }
}
