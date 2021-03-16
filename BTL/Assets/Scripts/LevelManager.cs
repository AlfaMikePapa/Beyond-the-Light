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
        StartCoroutine(EndLevelCoroutine());
    }

    public IEnumerator EndLevelCoroutine()
    {
        CameraController.instance.stopFollowing = true;

        yield return new WaitForSeconds(1.5f);

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + .25f);

        SceneManager.LoadScene(nextLevel);
    }

    public void RestartLevel()
    {
        StartCoroutine(RestartLevelCoroutine());
    }

    public IEnumerator RestartLevelCoroutine()
    {
        yield return new WaitForSeconds(1.5f);

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + .25f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
