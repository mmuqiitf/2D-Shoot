using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public GameObject deathEffect;

    private void Update()
    {
        if (health <= 0) {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController _player = collision.collider.GetComponent<PlayerController>();
        if (_player != null)
        {
            _player.DamagePlayer(1);
        }
    }
}
