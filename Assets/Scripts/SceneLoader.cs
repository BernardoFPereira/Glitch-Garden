using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float autoLoadNextLevelAfter;

    void Start()
    {
        if (autoLoadNextLevelAfter == 0)
        {
            Debug.Log("Scene auto load disabled");
        }
        else
        {
            Invoke("LoadNextScene", autoLoadNextLevelAfter);
        }
    }

    public void LoadScene(string name)
    {
        Debug.Log("New level Load: " + name);
        SceneManager.LoadScene(name);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        print("Quit requested");
        Application.Quit();
    }
}