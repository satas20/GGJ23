using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueprint : MonoBehaviour
{
    private bool collide;
    // Start is called before the first frame update
    void Start()
    {
        collide = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            //blueprint on.
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") { collide = true; }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") { collide = false; }

    }
}
