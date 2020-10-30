using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int health;

    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 moveVelocity;
    public float speed;

    private float move;
    public float jumpSpeed = 700;

    private bool isJumping;

    public bool facingRight = true;

    public int fallBoundary = -20;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed));
            Debug.Log("jump");
            isJumping = true;
        }

        if (transform.position.y <= fallBoundary)
        {
            GameManager.KillPlayer(this);
        }


    }


    void FixedUpdate()
    { 
        //rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

        float move = Input.GetAxis("Horizontal");

        if (move < 0 && facingRight) Flip();
        if (move > 0 && !facingRight) Flip();
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Air")
        {
            Destroy(other.gameObject);
        }
    }


}
