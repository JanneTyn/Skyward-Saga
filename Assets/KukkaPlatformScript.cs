using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KukkaPlatformScript : MonoBehaviour
{
    //public GameObject varsi;
    public GameObject kukka;
    // Start is called before the first frame update
    void Start()
    {
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
            kukka.SetActive(true);
        }
        else
        {
            //varsi.SetActive(false);
            kukka.SetActive(false);
        }
    }
}
