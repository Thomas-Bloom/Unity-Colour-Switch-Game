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
    public float minJumpHeight;
    public float maxJumpHeight;
    private bool isJumping = false;
    private bool jumpCancel = false;

    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        // Get player input -> Horizontal movement
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Apply horizontal movement
        rb.velocity = new Vector2(moveHorizontal * moveSpeed * Time.deltaTime, rb.velocity.y);

        // Check to see if player wants to jump
        if (isGrounded && Input.GetKey(KeyCode.Space)) {
            isJumping = true;
        }

    }

    private void FixedUpdate() {
        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,
            whatIsGround);

        if (isJumping) {
            LargeJump();
            isJumping = false;
        }
        if (jumpCancel) {
            if(rb.velocity.y > minJumpHeight) {
                smallJump();
            }
            jumpCancel = false;
        }

    }

    public void smallJump() {
        rb.AddForce(new Vector2(rb.velocity.x, minJumpHeight));
    }

    public void LargeJump() {
        rb.AddForce(new Vector2(rb.velocity.x, maxJumpHeight));
    }
}
