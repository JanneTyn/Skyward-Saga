using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeikkoScript : MonoBehaviour
{
    
    private Animator anim;
    
    NavMeshAgent agent;

    void Start()
    {
        anim = GetComponent<Animator>();
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
    }
    public void PeikkoFreeze(bool sunActive)
    {
       
        if (!sunActive)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
            anim.Play("palautuminen0");
            gameObject.tag = "Enemy";
        }
        else
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            anim.Play("kivetys_001");
            gameObject.tag = "Untagged";


        }



    }
}
