using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirScript : MonoBehaviour
{
    public int value = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(value);
        }
    }

}
