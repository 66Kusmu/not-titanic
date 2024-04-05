using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMovement : MonoBehaviour
{
    [Range(10, 50)]
    public float speed;
    private float maxspeed = 50;
    public GameObject boat;

    private TimerScript timer;

    public Slider speedSlider;

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.FindWithTag("Timer").GetComponent<TimerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        speedSlider.value = speed / maxspeed;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += boat.transform.forward * speed * Time.deltaTime;

        float angle = horizontal;

        if (timer.TimeLeft > 0)
            boat.transform.Rotate(new Vector3(0, angle * 3, 0), Space.Self);

        if(vertical > 0 && speed < maxspeed && timer.TimeLeft > 0)
        {
            if(speed + vertical / 2 > maxspeed)
            {
                speed = maxspeed;
            }
            else
            {
                speed += vertical / 2;
            }
        }

        if(vertical < 0 && speed > 10f)
        {
            if (speed + vertical / 2 < 10f)
            {
                speed = 10f;
            }
            else
            {
                speed += vertical / 2;
            }
        }

        if (timer.TimeLeft <= 0)
        {
            Debug.Log(speed);
            if (speed > 0.05f)
            {
                speed *= 0.95f;
            }
            else
            {
                speed = 0f;
            }
            boat.SetActive(false);
        }
    }
}

//Käytetyt oppaat:
//https://docs.unity3d.com/ScriptReference/Transform.Rotate.html (Transform.Rotate Unity dokumentaatio)
//https://docs.unity3d.com/ScriptReference/Vector3-forward.html (Vector3.forward Unity dokumentaatio)
//https://docs.unity3d.com/ScriptReference/GameObject.FindWithTag.html (GameObject.FindWithTag Unity dokumentaatio)
//https://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html (Collider.OnTriggerEnter(Collider) Unity dokumentaatio) Icebergiin