using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{
    public float speed;
    public float lifeTime;
    public float distance;
    public int damage = 1;
    public LayerMask whatIsSolid;

    public GameObject destroyEffect;
    public static Projectile instance;
    public int value;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            DestroyProjectile();

            if (hitInfo.collider.CompareTag("Boss"))
            {
                hitInfo.collider.GetComponent<Boss>().TakeDamage(damage);
            }
            DestroyProjectile();
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile() {
        GameObject clone = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(clone, 0.5f);
    }

    public IEnumerator Powerup()
    {
        damage = 3;
        yield return new WaitForSeconds(5f);
        damage = 1;
    }
}
