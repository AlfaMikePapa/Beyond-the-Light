using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu2 : MonoBehaviour
{
    /*
     *
     * Main Menu button functions
     * This part includes funcitons for main menu, settings menu, credits menu and level selection
     *
     */

    //Main Menu play button function
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    //Main Menu Settings button function
    public void OpenSettings()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
   
    //Main Menu Credits button functions
    public void CreditsBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    //Main Menu quit button function
    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit"); //Tells Unity console when game closes
    }



    /*
     *
     * Functions for credits menu
     *
     */

    //Credits menu BackBtn functions
    public void CrdBackBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }


    /*
     *
     * Functions for settings menu
     *
     */

    // Settings menu Back button functions
    public void BackBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }





    /*
    *
    * Functions for level selection menu
    *
    */
    // Level selection menu back button
    public void LvlSelcBackBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }

    // Select level 1
    public void Lvl1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
