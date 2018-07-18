using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour 
{
    private SceneLoader sceneManager;

	void Start () 
    {
        sceneManager = FindObjectOfType<SceneLoader>();
	}

    void OnTriggerEnter2D()
    {
        sceneManager.LoadScene("03B Lose");
    }
}
