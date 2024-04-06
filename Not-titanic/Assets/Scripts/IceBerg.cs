using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBerg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Iceberg needs collider and rigidbody
        //Debug.Log(other.gameObject.tag + " has triggered");
    }
}
