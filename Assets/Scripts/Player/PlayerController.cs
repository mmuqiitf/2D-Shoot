﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public PlayerController instance;

    public float health;
    public GameObject endGamePanel;
    public GameObject failTitle;
    public GameObject successTitle;

    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 moveVelocity;
    public float speed;

    private float move;
    public float jumpSpeed;

    private bool isJumping;

    public bool facingRight = true;

    public int fallBoundary = -20;

    public Slider playerHealthBar;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);
    }


    private void Update()
    {
        playerHealthBar.value = health;

        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed));
            Debug.Log("jump");
            isJumping = true;
        }

        if (transform.position.y <= fallBoundary)
        {
            Destroy(gameObject);
            endGamePanel.SetActive(true);
            failTitle.SetActive(true);
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

    public void DamagePlayer(int damage)
    {
        health -= damage;
        Debug.Log("Player Health : " + health);
        if (health <= 0)
        {
            Destroy(gameObject);
            endGamePanel.SetActive(true);
            failTitle.SetActive(true);
        }
    }

    public void PlayerWins()
    {
        endGamePanel.SetActive(true);
        successTitle.SetActive(true);
    }
}
