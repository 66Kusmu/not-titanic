using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Update is called once per frame



public class TimerScript : MonoBehaviour
{

    //https://www.youtube.com/watch?v=hxpUk0qiRGs The tutorial for making simple countdown.

    private float minutes;
    private float seconds;

    public float TimeStart;
    public float TimeLeft;
    public bool TimerOn = false;

    private ShipMovement player;

    public int timeExtention = 1;

    void Start()
    {
        TimerOn = true;
        TimeLeft = TimeStart;

        player = GameObject.FindWithTag("Player").GetComponent<ShipMovement>();
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime/timeExtention;
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
            }
            updateTimer(TimeLeft);
        }

        player.TimerSlider.value = 1 - (TimeLeft / TimeStart);
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;
        if (currentTime > TimeStart + 1)
        {
            minutes = Mathf.FloorToInt(TimeStart / 60);
            seconds = Mathf.FloorToInt(TimeStart % 60);

            player.TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds) + " + " + Mathf.FloorToInt(currentTime - TimeStart).ToString();
        }
        else
        {
            minutes = Mathf.FloorToInt(currentTime / 60);
            seconds = Mathf.FloorToInt(currentTime % 60);

            player.TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }

    }

}