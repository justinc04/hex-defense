using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float size;
    public int health;

    void Start()
    {
        size = PlayerStats.Instance.bulletSize;
        health = PlayerStats.Instance.bulletPierce;
        transform.localScale = new Vector3(size, size, 0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            health--;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);    
    }
}
