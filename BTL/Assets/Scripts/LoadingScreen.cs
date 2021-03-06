using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    
    void Start()
    {
       
       StartCoroutine(LoadingTimer());
    }

    //Timer for loading screen.
    public IEnumerator LoadingTimer()
    {
        int btn = MainMenu2.btnId;
        Debug.Log("Start loading level " + btn);
        yield return new WaitForSeconds(5f);
        Debug.Log("Lets go!");
        SceneManager.LoadScene("Level"+btn+"Scene");
    }
}
