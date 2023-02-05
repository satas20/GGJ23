using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTransparentLeaf : MonoBehaviour
{
    private GameObject childObject;
    private Color leafColor;
    private Color defaultleafColor;
    private float timer;
    private bool increaseAlpha;
    private bool decreaseAlpha;

    private void Awake()
    {
        timer = 10f;
    }

    private void Start()
    {
        childObject = transform.GetChild(0).gameObject;
        leafColor = childObject.GetComponent<Renderer>().material.color;
    }

    private void FixedUpdate()
    {
        if (decreaseAlpha)
        {
            decreaseAlphaFunc();
        }
        

        if (increaseAlpha)
        {
            increaseAlphaFunc();
        }
        



    }

    private void decreaseAlphaFunc()
    {
        Debug.Log(timer + "----");
        if (timer > 0)
        {
            timer -= Time.fixedDeltaTime;
            if (leafColor.a > 0.33f) { leafColor.a -= 0.04f; Debug.Log("111"); } else { leafColor.a = 0.33f; Debug.Log("222"); }
            transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = leafColor;
        }
        else { timer = 10f; }
    }

    private void increaseAlphaFunc()
    {
        Debug.Log(timer + "+++");
        if (timer > 0)
        {
            timer -= Time.fixedDeltaTime;
            if (leafColor.a < 0.79f) { leafColor.a += 0.04f; Debug.Log("333"); } else { leafColor.a = 1f; Debug.Log("444"); }
            transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = leafColor;
        }
        else { timer = 10f; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            decreaseAlpha = true;
            increaseAlpha = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            increaseAlpha = true;
            decreaseAlpha = false;
        }
    }
}
