using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightKukkaPlatformScript : MonoBehaviour
{
    public GameObject kukka;
    public Animator flowerAnimation;
    // Start is called before the first frame update
    void Start()
    {
        flowerAnimation.GetComponent<Animator>().Play("nightClosed");
        kukka.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlowerChange(bool sunActive)
    {
        if (!sunActive)
        {

            Debug.Log("nightflower open");
            flowerAnimation.GetComponent<Animator>().Play("nightOpen");
            kukka.GetComponent<BoxCollider>().enabled = true;
            //kukka.SetActive(true);
        }
        else
        {
            Debug.Log("nightflower close");
            flowerAnimation.GetComponent<Animator>().Play("nightClosed");
            kukka.GetComponent<BoxCollider>().enabled = false;
            //kukka.SetActive(false);
        }
    }
}
