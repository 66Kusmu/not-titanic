using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMenu : MonoBehaviour
{
    public float speed;
    private float maxspeed = 50;
    public GameObject boat;

    public ParticleSystem splashL, splashR;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float angle = horizontal;

        boat.transform.Rotate(new Vector3(0, angle * 3, 0), Space.Self);

        if (vertical > 0 && speed < maxspeed)
        {
            if (speed + vertical / 2 > maxspeed)
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

        if (vertical < 0 && speed > 10f)
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
    }
}
