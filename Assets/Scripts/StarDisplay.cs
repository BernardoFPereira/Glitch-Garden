﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour 
{
    private Text starText;
    private int stars = 0;

    // Use this for initialization
	void Start () 
    {
        starText = GetComponent<Text>();
        print(starText);
	}
	

    public void AddStarts(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void UseStars(int amount)
    {
        stars -= amount;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }
}