using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collectables : MonoBehaviour
{
    
    public static event Action OnCollected;
    public static int total;
    public Animator coll;
    private AudioSource collectSound;

    void Awake() => total++;
    
    void Start()
    {
        coll.GetComponent<Animator>().Play("collidle");
    }
    

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            StartCoroutine(CollDest());
            
            OnCollected?.Invoke();


        }
    }

        IEnumerator CollDest()
        {
        coll.GetComponent<Animator>().Play("collcolle");
        gameObject.GetComponent<AudioSource>().time = 0.2f;
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);

    }
    
}
