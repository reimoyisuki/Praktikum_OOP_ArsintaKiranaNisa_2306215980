using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; // Reference to the Rigidbody2D component

    public Vector2 maxSpeed = new Vector2(5f, 5f); // Maximum speed in each direction
    public Vector2 timeToFullSpeed = new Vector2(1f, 1f); // Time to reach max speed
    public Vector2 timeToStop = new Vector2(0.5f, 0.5f); // Time to stop when input is released
    public Vector2 stopClamp = new Vector2(2.5f, 2.5f); // Minimum speed threshold before stopping

    private Vector2 currentSpeed; // Current speed of the player
    private Vector2 moveDirection; // Direction of movement based on player input
    private Vector2 moveVelocity; // Velocity applied to the player when moving
    private Vector2 moveFriction; // Friction applied when player is moving
    private Vector2 stopFriction; // Friction applied when player is stopping
    private bool isMoving = false; // Indicates if the player is moving

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveVelocity = new Vector2(
            2 * maxSpeed.x / timeToFullSpeed.x,
            2 * maxSpeed.y / timeToFullSpeed.y
        );

        moveFriction = new Vector2(
            -2 * maxSpeed.x / (timeToFullSpeed.x * timeToFullSpeed.x),
            -2 * maxSpeed.y / (timeToFullSpeed.y * timeToFullSpeed.y)
        );

        stopFriction = new Vector2(
            -2 * maxSpeed.x / (timeToStop.x * timeToStop.x),
            -2 * maxSpeed.y / (timeToStop.y * timeToStop.y)
        );

    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        // Retrieve player input for movement
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.W)) verticalInput = 1f; 
        if (Input.GetKey(KeyCode.S)) verticalInput = -1f; 
        if (Input.GetKey(KeyCode.D)) horizontalInput = 1f; 
        if (Input.GetKey(KeyCode.A)) horizontalInput = -1f; 

        // Calculate the move direction based on input
        moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Calculate the applied movement velocity based on the direction and moveVelocity
        Vector2 appliedVelocity = new Vector2(
            moveVelocity.x * moveDirection.x,
            moveVelocity.y * moveDirection.y
        );

        // Update the Rigidbody2D velocity with the calculated new velocity
        rb.velocity = new Vector2(moveDirection.x * maxSpeed.x, moveDirection.y * maxSpeed.y);
    }

    private Vector2 GetFriction()
    {
        Vector2 appliedFriction = Vector2.zero;

        if (Mathf.Abs(rb.velocity.x) > 0)
        {
            appliedFriction.x = isMoving ? moveFriction.x : stopFriction.x;
        }

        if (Mathf.Abs(rb.velocity.y) > 0)
        {
            appliedFriction.y = isMoving ? moveFriction.y : stopFriction.y;
        }

        return appliedFriction;
    }

    public bool IsMoving()
    {
        if (rb.velocity.magnitude > 0) return true;
        else return false;
    }
}