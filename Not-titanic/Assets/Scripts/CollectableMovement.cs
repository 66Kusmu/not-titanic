using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollectableMovement : MonoBehaviour
{
    private List<Transform> points;
    private NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        GameObject go = GameObject.FindGameObjectWithTag("WayPoints");
        foreach (Transform t in go.transform)
        {
            points.Add(t);
        }

        agent.SetDestination(points[Random.Range(0, points.Count)].position);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(agent.destination + " " + agent.remainingDistance);
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(points[Random.Range(0, points.Count)].position);
        }
    }
}
