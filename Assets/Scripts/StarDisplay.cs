﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour 
{
    public enum Status { SUCCESS, FAILURE };
    public int stars = 100;


    private Text starTotal;

    void Start () 
    {
        starTotal = GetComponent<Text>();
        UpdateDisplay();
	}
	

    public void AddStarts(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public Status UseStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }

    private void UpdateDisplay()
    {
        starTotal.text = stars.ToString();
    }
}
