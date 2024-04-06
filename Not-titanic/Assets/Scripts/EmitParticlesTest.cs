using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitParticlesTest : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            particleSystem.Emit(30);
        }
    }
}

//Testiskripti

//Lähde:
//https://docs.unity3d.com/ScriptReference/ParticleSystem.Emit.html
