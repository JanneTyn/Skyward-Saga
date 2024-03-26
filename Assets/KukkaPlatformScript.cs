using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KukkaPlatformScript : MonoBehaviour
{
    //public GameObject varsi;
    public GameObject kukka;
    public Animator flowerAnimation;
    // Start is called before the first frame update
    void Start()
    {       
        //flowerAnimation = GetComponent<Animator>();
        //varsi = GameObject.Find("Varsi");
        //varsi = GameObject.Find("Varsi");
        //kukka = GameObject.Find("Kukka");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FlowerChange(bool sunActive)
    {
        if (sunActive)
        {

            //varsi.SetActive(true);
            flowerAnimation.GetComponent<Animator>().Play("dayOpen");
            kukka.GetComponent<BoxCollider>().enabled = true;
            //kukka.SetActive(true);
        }
        else
        {
            //varsi.SetActive(false);
            flowerAnimation.GetComponent<Animator>().Play("dayClosed");
            kukka.GetComponent<BoxCollider>().enabled = false;
            //kukka.SetActive(false);
        }
    }
}
