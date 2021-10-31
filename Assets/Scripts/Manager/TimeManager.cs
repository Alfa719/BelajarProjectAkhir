using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    // Set timer gameplay
    public float startTime = 0, endTime = 60;
    public Slider timeSlider;
    void Start()
    {
        timeSlider.maxValue = endTime;
    }

    // Update is called once per frame
    void Update()
    {
        endTime -= Time.deltaTime;
        timeSlider.value = endTime;
    }
}
