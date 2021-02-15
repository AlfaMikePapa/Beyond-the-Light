using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu2 : MonoBehaviour
{
    //Main Menu play button function
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Main Menu Settings button function
    public void OpenSettings()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
   
    // Settings menu Back button functions
    public void BackBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    //Main Menu Credits button functions
    public void CreditsBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    //Credits menu BackBtn functions
    public void CrdBackBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
    //Main Menu quit button function
    public void QuitGame()
    {
        Application.Quit();
    }

}
