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

    [Header("Death")]
    public Transform spawnPoint;
    public ParticleSystem deathParticles;
    public bool playerIsAlive;

    private void Start() {
        transform.position = spawnPoint.position;
        rb = GetComponent<Rigidbody2D>();
        deathParticles.gameObject.SetActive(false);
        playerIsAlive = true;

    }

    private void Update() {
        var deathParticleMain = deathParticles.main;
        deathParticleMain.startColor = GetComponent<SpriteRenderer>().color;
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

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("KillPlayer")) {
            killPlayer();
            StartCoroutine(waitForSpawn(2f));
        }
    }

    public void killPlayer () {
        playerIsAlive = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        deathParticles.gameObject.SetActive(true);
    }

    public void spawnPlayer() {
        playerIsAlive = true;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<PlayerController>().enabled = true;
        GetComponent<Rigidbody2D>().isKinematic = false;
        transform.position = spawnPoint.position;
        deathParticles.gameObject.SetActive(false);
    }

    private IEnumerator waitForSpawn(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        spawnPlayer();
    }
}
