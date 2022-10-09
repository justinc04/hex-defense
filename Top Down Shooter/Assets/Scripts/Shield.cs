using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject halo;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            halo.SetActive(false);
            gameObject.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(RegenTimer());
        }
    }

    IEnumerator RegenTimer()
    {
        yield return new WaitForSeconds(PlayerStats.Instance.shieldRegenTime);
        halo.SetActive(true);
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
