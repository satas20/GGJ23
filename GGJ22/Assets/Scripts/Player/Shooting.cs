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
    public bool isFire = false;

    public AudioClip pistolShot;
    public AudioSource aSource;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
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
            aSource.Play();
            isFire = true;
            if(GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelBar>().PlayerLevel <= 3)
            {
                LugerShoot();
            }
            else if( GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelBar>().PlayerLevel>3)
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
        Debug.Log("LuggerShot" + " level" + GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelBar>().PlayerLevel);
        fireRate = 0.5f;
        bulletSpeed = 10f;

        nextFireTime = Time.time + fireRate;
        
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Vector2 direction = (mousePosition - firePointPosition).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePointPosition, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed * GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelBar>().PlayerLevel ;

    }

    void M1CarbineShoot()
    {
        fireRate = 0.5f;
        bulletSpeed = 30f;

        
        nextFireTime = Time.time + fireRate;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Vector2 direction = (mousePosition - firePointPosition).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePointPosition, Quaternion.identity);
        bullet.GetComponent<Bullet>().damage = 30;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed * GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelBar>().PlayerLevel; ;
        //frontCanva.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = gunSprites[1];

    }

  

    void DontShoot()
    {
        //frontCanva.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = null;

    }
}
