using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Update is called once per frame



public class TimerScript : MonoBehaviour
{

    //https://www.youtube.com/watch?v=hxpUk0qiRGs The tutorial for making simple countdown.

    public float TimeStart;
    public float TimeLeft;
    public bool TimerOn = false;

    public Text TimerTxt;
    public Slider TimerSlider;

    void Start()
    {
        TimerOn = true;
        TimeLeft = TimeStart;
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
            }
        }

        TimerSlider.value = TimeLeft / TimeStart;
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

}