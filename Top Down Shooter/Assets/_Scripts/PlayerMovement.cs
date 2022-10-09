using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Joystick joystick;
    public GameObject shield;

    void Start()
    {
        shield.SetActive(PlayerStats.Instance.shield);
    }

    void FixedUpdate()
    {
        if(joystick.Horizontal != 0f || joystick.Vertical != 0f)
        {
            float angle = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            GameManager.Instance.health--;
        }
    }
}
