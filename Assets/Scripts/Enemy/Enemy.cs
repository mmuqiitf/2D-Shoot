using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public GameObject deathEffect;
    public int damage;

    public int scoreValue;

    private void Update()
    {
        if (health <= 0) {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            ScoreManager.instance.ChangeScore(scoreValue);
        }
    }

    public void TakeDamage(int takeDamage)
    {
        health -= takeDamage;
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
