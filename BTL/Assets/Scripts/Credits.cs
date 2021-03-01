using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public static bool easterEggVisible = false;

    [SerializeField] GameObject easterEggVis;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
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
    }

    void PauseGame()
    {
        easterEggVis.SetActive(true);
        easterEggVisible = true;

    }

}
