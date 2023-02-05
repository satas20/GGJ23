using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueprint : MonoBehaviour
{
    private bool collide;
    private Animator anim;
    private bool locked = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        collide = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (!(locked))
            {
                locked = true;
                anim.SetBool("go", true);
                transform.GetChild(0).gameObject.SetActive(false);
                StartCoroutine(WaitASecon());
            }
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

    private IEnumerator WaitASecon()
    {
        yield return new WaitForSeconds(5);
        this.gameObject.SetActive(false);
    } 
}
