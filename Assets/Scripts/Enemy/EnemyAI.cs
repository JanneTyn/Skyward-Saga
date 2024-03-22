using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    private Animator anim;
    
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

    

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            
            IterateWayPointIndex();
            UpdateDestination();
            anim.Play("armidle");
            

        }


    }

    void UpdateDestination()
    {
        
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
        anim.Play("kävely");

    }

   
    void IterateWayPointIndex()
    {
        waypointIndex++;
        if(waypointIndex== waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
