using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingRockPlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerMovement playerMovement;
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.transform.tag == "Player")
        {
            playerMovement.rockCollision = true;
            Debug.Log("Player hits ball");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            playerMovement.rockCollision = false;
            Debug.Log("Player no longer hitting ball");
        }
    }
}
