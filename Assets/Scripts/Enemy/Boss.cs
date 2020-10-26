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
    //private Animator anim;

    private void Start()
    {
        //anim = GetComponent<Animator>();
    }

    private void Update()
    { 
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.value = health;
    }
}
