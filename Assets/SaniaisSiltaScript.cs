using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaniaisSiltaScript : MonoBehaviour
{
    public GameObject silta1;
    public GameObject silta2;
    
    // Start is called before the first frame update
    void Start()
    {
        silta1 = GameObject.Find("Silta1");
        silta2 = GameObject.Find("Silta2");
        silta1.SetActive(false);
        silta2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BridgeChange(bool sunActive)
    {
        if (!sunActive)
        {
            silta1.SetActive(true);
            silta2.SetActive(true);
            
        }
        else
        {
            silta1.SetActive(false); silta2.SetActive(false);
            
        }
    }
}
