using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

    public int health;
    public int damage;

    public GameObject deathEffect;
    //public Animator camAnim;
    public Slider healthBar;
    private Animator anim;

    public int scoreValue;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        anim.enabled = true;
        if (health <= 15)
        {
            anim.SetTrigger("stageTwo");
        }
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            ScoreManager.instance.ChangeScore(scoreValue);
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.value = health;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController _player = collision.collider.GetComponent<PlayerController>();
        if (_player != null)
        {
            _player.DamagePlayer(damage);
        }
    }
}
