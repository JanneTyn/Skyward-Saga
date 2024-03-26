using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaniaisSiltaScript : MonoBehaviour
{
    private Animator anim;
    
    
     
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BridgeChange(bool sunActive)
    {
        if (sunActive)
        {
            GetComponent<Collider>().enabled = false;
            anim.Play("saniclose");

        }
        else
        {
            GetComponent<Collider>().enabled = true;
            anim.Play("saniopen");
        }
    }
}
