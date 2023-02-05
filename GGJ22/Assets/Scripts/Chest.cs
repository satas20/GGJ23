using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private GameObject player;
    private bool openchest;
    private bool pressE;
    private GameObject cephane;
    private float timer = 2f;
    private Color cephaneColor;
    private Vector3 lower = new Vector3(0.2f, 0.2f, 0);
    private int randomType;
    private int randomValue;
    private bool atama = true;
    private bool again = true;
    private Vector3 defaultVector = new Vector3(2f, 2f, 1f);
    private Color defaultcephaneColor = new Color(1, 1, 1, 1);
    public GameObject[] prefabs;

    // Start is called before the first frame update
    void Start()
    {
        openchest = false;
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E)) { pressE = true; }
        if (pressE && openchest)
        {


            if (atama)
            {
                atama = false;

                cephane = Instantiate(prefabs[randomType], transform.position, Quaternion.identity);
                cephane.GetComponent<SpriteRenderer>().sortingOrder = 2;
                cephaneColor = cephane.GetComponent<Renderer>().material.color;
            }

            CephaneAnim();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if(collision.gameObject.tag == "Player")
        {
            randomType = Random.Range(0, 2);
            randomValue = Random.Range(5, 9);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            if (again) { openchest = true; }
            
        }
    }

    private void CephaneAnim()
    {


        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (cephaneColor.a > 0)
            {
                cephaneColor.a -= 0.01f;
                cephane.GetComponent<Renderer>().material.color = cephaneColor;

            }
            cephane.transform.localScale += lower;
        }
        else
        {
            timer = 2f;
            cephane.transform.position = new Vector3(0, 0, 0);
            Destroy(cephane);
            pressE = false;
            openchest = false;
            player.GetComponent<Shooting>().ammoCount += randomValue;
            cephane.transform.localScale = defaultVector;
            cephane.GetComponent<Renderer>().material.color = defaultcephaneColor;
            StartCoroutine(AnimationRoutine());
        }
    }

    private IEnumerator AnimationRoutine()
    {
        float timer = 2f;
        again = false;
        yield return new WaitForSeconds(timer);
        again = true;
        atama = true;
    }
}
