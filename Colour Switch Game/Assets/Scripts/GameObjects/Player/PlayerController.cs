using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float groundCheckRadius;
    public bool isGrounded;
    [Header("Movement")]
    public float moveSpeed;
    public float jumpHeight;
    private float moveHorizontal;
    public float gravity = 1f;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        // Check to see if player wants to jump
        if (isGrounded) {
            if (Input.GetButtonDown("Jump")) {
                rb.AddForce(new Vector2(0, jumpHeight));
            }
        }
    }

    private void FixedUpdate() {
        moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);

        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,
            whatIsGround);
    }
}
