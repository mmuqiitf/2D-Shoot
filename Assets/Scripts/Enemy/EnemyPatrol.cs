using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public float distance;
    public int damage;

    public bool movingRight = true;

    public Transform groundDetection;
    
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingRight == false)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingRight = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().health -= damage;
            Debug.Log("Player Health : " + other.GetComponent<PlayerController>().health);
        }
    }
}
