using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;
    private float nextFireTime;
    private Transform firePoint;
    public int gunNO;
    public GameObject frontCanva;
    public Sprite[] gunSprites;

    private Animator anim;
    private bool isFire = false;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("FirePoint object not found.");
        }
        gunNO = 4;
    }

    void Update()
    {
        anim.SetBool("fire", isFire);
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            isFire = true;
            if(gunNO == 0)
            {
                LugerShoot();
            }
            else if(gunNO == 1)
            {   
                M1CarbineShoot();
            }
            else if(gunNO == 2)
            {
                AxeShoot();
            }
            else
            {
                DontShoot();
            }
           
        }
        if (Input.GetMouseButtonUp(0)){
            isFire = false;
        }
        
    }
    
    void LugerShoot()
    {
        nextFireTime = Time.time + fireRate;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Vector2 direction = (mousePosition - firePointPosition).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePointPosition, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 10f;

    }

    void M1CarbineShoot()
    {
        nextFireTime = Time.time + fireRate;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Vector2 direction = (mousePosition - firePointPosition).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePointPosition, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 10f;
        frontCanva.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = gunSprites[1];

    }

    void AxeShoot()
    {
        nextFireTime = Time.time + fireRate;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Vector2 direction = (mousePosition - firePointPosition).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePointPosition, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 10f;
        frontCanva.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = gunSprites[2];

    }

    void DontShoot()
    {
        frontCanva.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = null;

    }
}
