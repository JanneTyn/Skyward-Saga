using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressureTileCenterPointCollision : MonoBehaviour
{

    public GameObject vinePlatform;
    public Animator vineAnimator;
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
        if (collision.transform.tag == "RollingRock")
        {
            Debug.Log("Kivi kohteessa");
            vineAnimator.GetComponent<Animator>().Play("lehdetAlas");
            //vinePlatform.SetActive(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "RollingRock")
        {
            Debug.Log("Kivi poissa");
            vineAnimator.GetComponent<Animator>().Play("lehdetYlos");
            //vinePlatform.SetActive(true);
        }
    }
}
