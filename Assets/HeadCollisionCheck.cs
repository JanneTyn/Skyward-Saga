using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollisionCheck : MonoBehaviour
{
    public PlayerMovement playermovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.name != "Player")
        {
            Debug.Log("Ceiling hit");
            playermovement.ceilingHit = true;
        }      
    }
}
