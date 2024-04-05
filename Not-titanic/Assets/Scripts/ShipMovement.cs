using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public int speed;
    private int maxspeed = 30;
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

        if(vertical != 0)
        {
            Debug.Log("Speed is changed");
        }
    }
}

//Käytetyt oppaat:
//https://docs.unity3d.com/ScriptReference/Transform.Rotate.html (Transform.Rotate Unity dokumentaatio)
//https://docs.unity3d.com/ScriptReference/Vector3-forward.html (Vector3.forward Unity dokumentaatio)