using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnable;
    private float time;
    private int requiredTime = 2;
    private GameObject[] points;

    // Start is called before the first frame update
    void Start()
    {
        points = GameObject.FindGameObjectsWithTag("WayPoints");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= requiredTime)
        {
            Instantiate(spawnable, points[Random.Range(0, points.Length)].transform.position, Quaternion.identity);
            time -= requiredTime;
            requiredTime += 2;
        }
    }
}
