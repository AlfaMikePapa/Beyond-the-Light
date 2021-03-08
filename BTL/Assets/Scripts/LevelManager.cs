using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public string nextLevel;

    private void Awake()
    {
        instance = this;
    }

    public void EndLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
