using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBerg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //first we make sure that the object that hit the banana is the player.
        if (collision.gameObject.tag == "Player")
        {
            // This will search all player scripts for a function called "Hit Banana"
            Debug.Log("Banana was hit by player");
        }
    }

    

}
