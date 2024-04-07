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
    public Text speedText;

    public Text TimerTxt;
    public Slider TimerSlider;

    private float time;

    public Image gameOver;

    public ParticleSystem splashL, splashR;

    public float ConstraintX, ConstraintY;

    public AudioClip penguin, plank;
    private AudioSource voice;

    public Image Pen1, Pen2, Pen3;

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.FindWithTag("Timer").GetComponent<TimerScript>();
        voice = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        speedSlider.value = speed / maxspeed;
        speedText.text = "Speed: " + Mathf.FloorToInt(speed).ToString();

        if(timer.timeExtention > 1)
            Pen1.gameObject.SetActive(true);
        else
            Pen1.gameObject.SetActive(false);

        if (timer.timeExtention > 2)
            Pen2.gameObject.SetActive(true);
        else
            Pen2.gameObject.SetActive(false);

        if (timer.timeExtention > 3)
            Pen3.gameObject.SetActive(true);
        else
            Pen3.gameObject.SetActive(false);

        if(timer.TimeLeft <= 0 && speed < 1f)
        {
            gameOver.GetComponent<GameOver>().dead = true;
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (transform.position.x >= ConstraintX || transform.position.x <= -ConstraintX || transform.position.z >= ConstraintY || transform.position.z <= -ConstraintY)
        {
            transform.position += boat.transform.forward * (speed / Mathf.Pow(Vector3.Distance(Vector3.zero, transform.position) / 100, 3)) * Time.deltaTime;
            Debug.Log(Vector3.Distance(Vector3.zero, transform.position) / 100 * (Vector3.Distance(Vector3.zero, transform.position) / 100));
        }
        else
        {
            transform.position += boat.transform.forward * speed * Time.deltaTime;
        }
        
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
                splashL.emissionRate += vertical / 2;
                splashR.emissionRate += vertical / 2;
            }
        }

        if(vertical < 0 && speed > 10f && timer.TimeLeft > 0)
        {
            if (speed + vertical / 2 < 10f)
            {
                speed = 10f;
            }
            else
            {
                speed += vertical / 2;
                splashL.emissionRate += vertical / 2;
                splashR.emissionRate += vertical / 2;
            }
        }

        if (timer.TimeLeft <= 0)
        {
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

        if (timer.timeExtention > 1)
        {
            time += Time.deltaTime;

            if (time >= 4f)
            {
                timer.timeExtention -= 1;
                time = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Iceberg")
        {
            if (timer.TimeLeft <= 20f)
                timer.TimeLeft = 0;
            else
                timer.TimeLeft -= 20f;

            other.gameObject.GetComponent<EmitParticlesTest>().EmitHitParticle();
            other.gameObject.GetComponent<AudioSource>().Play();
        }

        if (other.gameObject.tag == "Penguin")
        {
            if (timer.timeExtention < 1)
            {
                timer.timeExtention *= 2;
            }
            if (timer.timeExtention < 4 && timer.timeExtention >= 1)
            {
                timer.timeExtention += 1;
            }
            Destroy(other.gameObject);
            voice.PlayOneShot(penguin);
        }

        if (other.gameObject.tag == "Plank" && timer.TimeLeft > 0)
        {
            timer.TimeLeft += 20f;
            Destroy(other.gameObject);
            voice.PlayOneShot(plank);
        }
    }
}

//Käytetyt oppaat:
//https://docs.unity3d.com/ScriptReference/Transform.Rotate.html (Transform.Rotate Unity dokumentaatio)
//https://docs.unity3d.com/ScriptReference/Vector3-forward.html (Vector3.forward Unity dokumentaatio)
//https://docs.unity3d.com/ScriptReference/GameObject.FindWithTag.html (GameObject.FindWithTag Unity dokumentaatio)
//https://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html (Collider.OnTriggerEnter(Collider) Unity dokumentaatio) Icebergiin
//https://www.youtube.com/watch?v=whkC8f3oNOk (3D ENEMY AI in UNITY - (E01): STATE MACHINE BEHAVIORS) CollectableMovementiin
//https://www.youtube.com/watch?v=WiUUW9RSa5Y (Unity Tutorial - How to create a fade away text display) GameOveriin
//https://docs.unity3d.com/ScriptReference/Vector3.Distance.html (Vector3.Distance Unity dokumentaatio)