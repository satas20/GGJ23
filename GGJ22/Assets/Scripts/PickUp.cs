using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{
    
    private bool deneme;
    private bool f�r�n;
    private GameObject ceset;
    private void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.E) && deneme == true)
        {
            //Perform the pickup logic here
            Debug.Log("Picked up item!");

            Destroy(ceset);
        }
        if (Input.GetKeyDown(KeyCode.E) && f�r�n == true)
        {


        }
    }
}
