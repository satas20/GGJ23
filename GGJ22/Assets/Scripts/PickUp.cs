using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{
    
    private bool deneme;
    private bool f�r�n;
    private GameObject ceset;
    private GameObject f�r�nObject;

    public bool isBurning;
    private void Start()
    {
        isBurning = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Ceset")
        {
            deneme = true;
            ceset = collision.gameObject;

        }
        if (collision.gameObject.tag == "F�r�n")
        {
            f�r�n = true;
            f�r�nObject = collision.gameObject;

        }
        if (collision.gameObject.tag == "cephane")
        {
            this.gameObject.GetComponent<Shooting>().ammoCount += Random.Range(3, 5);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ceset")
        {
            
            deneme = false;
            
        }
        if (collision.gameObject.tag == "F�r�n")
        {

            f�r�n = false;

        }

    }

    private void Update()
    {
        isBurning = false;

        if (Input.GetKeyDown(KeyCode.E) && deneme == true)
        {
            //Perform the pickup logic here
            Debug.Log("Picked up item!");
            GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelBar>().cesetCount++;
            Destroy(ceset);
        }
        if (Input.GetKeyDown(KeyCode.E) && f�r�n == true)
        {
            isBurning = true;
            f�r�nObject.GetComponent<Animator>().SetBool("isBurn", isBurning);

            GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelBar>().exp +=GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelBar>().cesetCount++;
            GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelBar>().cesetCount=0;

        }
        
    }
}
