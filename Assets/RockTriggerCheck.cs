using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTriggerCheck : MonoBehaviour
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
        Debug.Log(collision.gameObject.name);
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Player hit ball");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Player left ball");
        }
    }
}
