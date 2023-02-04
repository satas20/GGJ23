using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{
    
    private bool deneme;
    private bool fýrýn;
    private GameObject ceset;
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("111");

        if (collision.gameObject.tag == "Ceset")
        {
            deneme = true;
            ceset = collision.gameObject;

        }
        if (collision.gameObject.tag == "Fýrýn")
        {
            fýrýn = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ceset")
        {
            
            deneme = false;
            
        }
        if (collision.gameObject.tag == "Fýrýn")
        {

            fýrýn = false;

        }
        //Debug.Log("222");

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && deneme == true)
        {
            //Perform the pickup logic here
            Debug.Log("Picked up item!");
            GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelBar>().cesetCount++;

            Destroy(ceset);
        }
        if (Input.GetKeyDown(KeyCode.E) && fýrýn == true)
        {

            GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelBar>().exp += GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelBar>().cesetCount;

            GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelBar>().cesetCount=0;
        }
    }
}
