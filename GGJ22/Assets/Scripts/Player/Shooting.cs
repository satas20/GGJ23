using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float fireRate;
    private float bulletSpeed;
    private float nextFireTime;
    private Transform firePoint;
    public int gunNO;
    public int levelValue=1;
    public GameObject frontCanva;
    public Sprite[] gunSprites;
    public TMP_Text ammoCounter;
    public int ammoCount;
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
        gunNO = 1;
    }

    void Update()
    {
        ammoCounter.text = ("x "+ammoCount.ToString());
        anim.SetBool("fire", isFire);
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime && ammoCount>0)
        {
            ammoCount --;
            isFire = true;
            if(gunNO == 0)
            {
                LugerShoot();
            }
            else if(gunNO == 1)
            {   
                M1CarbineShoot();
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
        fireRate = 0.5f;
        bulletSpeed = 10f;

        nextFireTime = Time.time + fireRate;
        
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Vector2 direction = (mousePosition - firePointPosition).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePointPosition, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

    }

    void M1CarbineShoot()
    {
        fireRate = 2f;
        bulletSpeed = 30f;

        
        nextFireTime = Time.time + fireRate;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Vector2 direction = (mousePosition - firePointPosition).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePointPosition, Quaternion.identity);
        bullet.GetComponent<Bullet>().damage = 30;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        //frontCanva.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = gunSprites[1];

    }

  

    void DontShoot()
    {
        //frontCanva.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = null;

    }
}
