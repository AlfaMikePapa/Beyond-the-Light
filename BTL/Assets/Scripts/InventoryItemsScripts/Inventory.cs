using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Canvas uiCanvas;
    public static bool isGamePaused = false;

    [SerializeField] GameObject inventoryMenu;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        inventoryMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        uiCanvas.enabled = true;
    }

    void PauseGame()
    {
        inventoryMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        uiCanvas.enabled = false;
    }

    /* Pause Menu button functions - spared if needed again
    public void LoadMenu() // Takes scene back to main menu
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LoadSettings() // Opens settings menu
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() // Quits the whole game
    {
        Application.Quit();

        Debug.Log("Quit"); //Tells Unity console when game closes
    } */
}
