using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public bool enteredHome;

    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (enteredHome)
            {
                enteredHome=false;
            }
            else
            {
                enteredHome=true;
            }
        }
    }

    private void Update()
    {
        if (enteredHome)
        {
            transform.parent.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            transform.parent.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
