using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private int isPlayed;
    private void Start()
    {
        isPlayed =PlayerPrefs.GetInt("isPlayed");
    }
    public void Play() {

        if (isPlayed == 1) {
            SceneManager.LoadScene("Level");
        }
        else
        {
            SceneManager.LoadScene("Tutorial");
            PlayerPrefs.SetInt("isPlayed", 1);
        }
       
        
       
    }
    public void Exit()
    {
        Application.Quit();
    }
}
