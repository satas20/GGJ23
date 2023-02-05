using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UıManager : MonoBehaviour
{
    public Sprite[] characters;
    public Sprite[] weapons;

    GameObject player;
    public GameObject animObject;
    public GameObject silahObject;

    private WaitForSeconds beklemesuresi;
    private bool isbool;
    private void Start()
    {
        isbool = true;
        beklemesuresi = new WaitForSeconds(5f);
        player = GameObject.FindGameObjectWithTag("Player");

        
    }
    private void Update()
    {
        int level = GetComponent<LevelBar>().PlayerLevel;
        switch (level) 
        {
            case 1:
                silahObject.GetComponent<Image>().sprite = weapons[0];

                break;
            case 2:
                silahObject.GetComponent<Image>().sprite = weapons[1];

                break;
            case 3:
                silahObject.GetComponent<Image>().sprite = weapons[2];
                break;
            case 4:
                silahObject.GetComponent<Image>().sprite = weapons[3];
                break;
            case 5:
                silahObject.GetComponent<Image>().sprite = weapons[4];
                break;
            case 6:
                silahObject.GetComponent<Image>().sprite = weapons[5];
                break;


        }
        Health healt = player.GetComponent<Health>();
        if (healt.currentHealth < 33)
        {
            animObject.GetComponent<Image>().sprite = characters[2];
            if (player.GetComponent<Shooting>().isFire)
            {
                animObject.GetComponent<Image>().sprite = characters[5];
                StartCoroutine(isimbu());

            }
        }
        else if (healt.currentHealth < 66)
        {
            animObject.GetComponent<Image>().sprite = characters[1];
            if (player.GetComponent<Shooting>().isFire)
            {
                animObject.GetComponent<Image>().sprite = characters[4];
                StartCoroutine(isimbu());

            }
        }

        else if (healt.currentHealth < 101 && isbool)
        {

          //  Debug.Log("2323");
            animObject.GetComponent<Image>().sprite = characters[0];
            if (player.GetComponent<Shooting>().isFire)
            {
                animObject.GetComponent<Image>().sprite = characters[3];
                StartCoroutine(isimbu());
                isbool = false;
            }

        }
        isbool = true;

    }


    private IEnumerator isimbu()
    {
        yield return beklemesuresi;
        
    }
}
