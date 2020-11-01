using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    public static PowerScript instance;
    public int value;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Projectile.instance.damage += value;
            Debug.Log("Damage : " + Projectile.instance.damage);
        }
    }

}