using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTimerScript : MonoBehaviour
{
    private float minutes;
    private float seconds;

    public float timeStart = 0;
    public Text textBox;

    bool timerActive = false;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = timeStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        timeStart += Time.deltaTime;

        minutes = Mathf.FloorToInt(timeStart / 60);
        seconds = Mathf.FloorToInt(timeStart % 60);

        textBox.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}


//https://www.youtube.com/watch?v=ijAN0QI70UU YT tutorial for both countdown and stopwatch scripts