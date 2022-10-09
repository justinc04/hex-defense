using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    bool canShoot = true;
    float offset;

    void Start()
    {
        offset = (PlayerStats.Instance.barrels - 1) * PlayerStats.Instance.bulletSize / 2f;
    }

    void Update()
    {
        if(canShoot && !GameManager.Instance.gameOver)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        CreateBullets();       
        yield return new WaitForSeconds(PlayerStats.Instance.reload);
        canShoot = true;
    }

    void CreateBullets()
    {
        GameObject[] bullets = new GameObject[PlayerStats.Instance.barrels];
        Vector3 firePos = firePoint.position - firePoint.right * offset;

        for (int i = 0; i < PlayerStats.Instance.barrels; i++)
        {
            bullets[i] = Instantiate(bulletPrefab, firePos, firePoint.rotation);
            firePos += firePoint.right * PlayerStats.Instance.bulletSize;
            Rigidbody2D rb = bullets[i].GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * PlayerStats.Instance.bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
