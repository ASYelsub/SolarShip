﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightManager : MonoBehaviour
{
    public Text dayNightLabelText;
    public Transform directionalLightTransform;


    //probably .01f
    public float dayChangeSpeed;
    float timeOfDay = 0f;
    public float startRotation;

    private void Start()
    {
        directionalLightTransform.transform.eulerAngles = new Vector3(startRotation, 0, 0);
        timeOfDay = startRotation;
    }
    private void FixedUpdate()
    {
       if(timeOfDay >= 360)
        {
            timeOfDay = 0;
        }
        else
        {
            timeOfDay += dayChangeSpeed;
            directionalLightTransform.transform.Rotate(dayChangeSpeed, 0, 0);
            dayNightLabelText.text = "Time of Day: " + (timeOfDay / 15).ToString();
        }
    }
}