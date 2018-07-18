using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    private StarDisplay starDisplay;

    void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    public void AddStars (int amount)
    {
        starDisplay.AddStarts(amount);
    }
}
