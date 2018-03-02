using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GroundChecks
{
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float groundCheckRadius;
    public bool isGrounded;
}

[System.Serializable]
public class Movement
{
    public float moveSpeed;
    public float jumpHeight;
}

public class PlayerController : MonoBehaviour {
    public GroundChecks gc;
    public Movement movement;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Check if player is grounded
        gc.isGrounded = Physics2D.OverlapCircle(gc.groundCheck.position, gc.groundCheckRadius,
            gc.whatIsGround);

        // Get player input -> Horizontal movement
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Apply horizontal movement
        rb.velocity = new Vector2(moveHorizontal * movement.moveSpeed, rb.velocity.y);

        // Jump
        if(gc.isGrounded && Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(rb.velocity.x, movement.jumpHeight));
    }
}
