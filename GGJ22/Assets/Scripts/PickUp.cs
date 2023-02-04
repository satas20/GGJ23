using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private bool deneme;

    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("111");

        if (collision.gameObject.tag == "Ceset")
        {
            deneme = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ceset")
        {
            deneme = false;
        }
        //Debug.Log("222");

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Perform the pickup logic here
            //Debug.Log("Picked up item!");
        }
    }
}
