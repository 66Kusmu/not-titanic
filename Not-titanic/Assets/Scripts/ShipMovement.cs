using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public int speed;
    public Rigidbody rd;

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

        Vector3 rdInput = Vector3.forward;
        rd.MovePosition(transform.position + Vector3.forward * Time.deltaTime * speed);
        Debug.Log(horizontal);

        float angle = horizontal;

        transform.Rotate(new Vector3(0, 0, angle), Space.Self);

        if (horizontal > 0)
        {
            //Quaternion desiredRotation = Quaternion.LookRotation(rdInput, Vector3.up);
            //transform.rotation = desiredRotation;
        }
        else if (rdInput == Vector3.zero)
        {
            //animator.SetBool("Moving", false);
        }
    }
}
