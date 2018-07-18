using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour 
{
    public float levelSeconds = 60;

    private Slider slider;
    private SceneLoader sceneManager;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private GameObject winLabel;

	// Use this for initialization
	void Start ()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        sceneManager = FindObjectOfType<SceneLoader>();

        FindWinText();
        winLabel.SetActive(false);
    }

    // Update is called once per frame
    void Update () 
    {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;
        TimeIsUp();
	}

    void FindWinText()
    {
        winLabel = GameObject.Find("Win Text");
        if (!winLabel)
        {
            Debug.LogWarning("Please create Win Text object");
        }
    }

    void TimeIsUp()
    {
        if(slider.value >= slider.maxValue && !isEndOfLevel)
        {
            audioSource.Play();
            winLabel.SetActive(true);
            Invoke("LoadNextLevel", audioSource.clip.length);
            Debug.Log("You Won!");
            isEndOfLevel = true;
        }
    }

    void LoadNextLevel()
    {
        sceneManager.LoadNextScene();
    }
}
