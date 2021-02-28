using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public Canvas BackGround;
    public static bool easterEggVisible = false;

    [SerializeField] GameObject easterEggVis;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            if (easterEggVisible)
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
        easterEggVis.SetActive(false);
        easterEggVisible = false;
        BackGround.enabled = false;
    }

    void PauseGame()
    {
        easterEggVis.SetActive(true);
        easterEggVisible = true;
        BackGround.enabled = true;

    }

}
