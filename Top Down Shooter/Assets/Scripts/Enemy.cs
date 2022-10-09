using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemySO enemy;
    public int health;
    float radius;
    int spinDirection;
    Color color;
    bool dead = false;

    void Start()
    {
        health = enemy.health;
        radius = Vector3.Distance(transform.position, Vector3.zero);
        color = gameObject.GetComponent<Renderer>().material.color;
        spinDirection = Random.Range(0, 2) * 2 - 1;
    }

    void Update()
    {
        if(!GameManager.Instance.gameOver)
        {
            transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, enemy.speed / 10f * Time.deltaTime);
            transform.Rotate(0f, 0f, spinDirection * enemy.spinSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.Instance.gameOver || dead)
        {
            return;
        }

        if(collision.tag == "Bullet") 
        {
            health -= PlayerStats.Instance.bulletDamage;

            if (health <= 0)
            {
                int moneyEarned = enemy.moneyValue + calculateBonus(Vector3.Distance(transform.position, Vector3.zero));
                PlayerStats.Instance.money += moneyEarned;

                Dead();
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, color.a - .5f);
                Invoke("ResetColor", .1f);
            }
        }
        else if(collision.tag == "Player")
        {
            Dead();
        }
    }

    int calculateBonus(float dist)
    {
        if(dist >= radius * 2/3f)
        {
            return enemy.longRangeBonus;
        }

        if(dist >= radius / 3f && dist < radius * 2/3f)
        {
            return enemy.mediumRangeBonus;
        }

        return 0;
    }

    void ResetColor()
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    void Dead()
    {
        dead = true;
        GameManager.Instance.progressCounter++;
        Destroy(gameObject);
    }
}
