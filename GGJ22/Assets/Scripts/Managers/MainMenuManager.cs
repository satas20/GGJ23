using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject Mainmenu;
    public GameObject Credits;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }
    public void Play()
    {

        SceneManager.LoadScene("CutScene");
        GetComponent<AudioSource>().Play();
    }
    public void playLevel()
    {

        SceneManager.LoadScene("Level");
        GetComponent<AudioSource>().Play();
    }
    public void loadMenu()
    {

        SceneManager.LoadScene("MainMenu");
        GetComponent<AudioSource>().Play();
    }
    public void credits()
    {
        Mainmenu.SetActive(false);
        Credits.SetActive(true);
        GetComponent<AudioSource>().Play();

    }
    public void CreditsBack()
    {

        Mainmenu.SetActive(true);
        Credits.SetActive(false);
        GetComponent<AudioSource>().Play();

    }
    public void Exit()
    {

        Application.Quit();
        GetComponent<AudioSource>().Play();

    }
}
