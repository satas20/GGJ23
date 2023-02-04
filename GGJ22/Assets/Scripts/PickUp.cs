using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject[] guns;
    private bool isGun = false;
    private string gunName;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Gun")
        {
            gunName = other.gameObject.name;
            isGun = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Gun")
        {
            gunName = "";
            isGun = false;
        }
    }

    private void Update()
    {
        if (isGun && Input.GetKeyDown(KeyCode.E))
        {
            for(int i = 0; i < guns.Length; i++)
            {
                if (guns[i].name == gunName)
                {
                    GetComponent<Shooting>().gunNO = i;
                }
            }
            Destroy(GameObject.FindWithTag("Gun"));
        }
    }
}
