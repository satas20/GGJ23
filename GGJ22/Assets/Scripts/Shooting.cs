using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;
    private float nextFireTime;
    private Transform firePoint;

    void Start()
    {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("FirePoint object not found.");
        }
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        nextFireTime = Time.time + fireRate;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Vector2 direction = (mousePosition - firePointPosition).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePointPosition, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 10f;
    }
}
