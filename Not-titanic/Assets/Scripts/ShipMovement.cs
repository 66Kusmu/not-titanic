using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [Range(10, 30)]
    public float speed;
    private float maxspeed = 30;
    public GameObject boat;

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

        transform.position += boat.transform.forward * speed * Time.deltaTime;

        float angle = horizontal;

        boat.transform.Rotate(new Vector3(0, angle * ((maxspeed - speed + 10)/10), 0), Space.Self);

        if(vertical > 0 && speed < maxspeed)
        {
            if(speed + vertical > maxspeed)
            {
                speed = maxspeed;
            }
            else
            {
                speed += vertical;
            }

            Debug.Log(speed);
        }

        if(vertical < 0 && speed > 10f)
        {
            if (speed + vertical < 10f)
            {
                speed = 10f;
            }
            else
            {
                speed += vertical;
            }

            Debug.Log(speed);
        }
    }
}

//Käytetyt oppaat:
//https://docs.unity3d.com/ScriptReference/Transform.Rotate.html (Transform.Rotate Unity dokumentaatio)
//https://docs.unity3d.com/ScriptReference/Vector3-forward.html (Vector3.forward Unity dokumentaatio)