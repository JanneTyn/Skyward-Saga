using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{
    public GameObject collect1;
    public GameObject collect2;
    public GameObject collect3;
    public GameObject collect4;

    public GameObject collCol1;
    public GameObject collCol2;
    public GameObject collCol3;
    public GameObject collCol4;

  

  
    void Update()
    {
        if (collect1.activeInHierarchy == false)
        {
            collCol1.gameObject.SetActive(true);
        }
        if (collect2.activeInHierarchy == false)
        {
            collCol2.gameObject.SetActive(true);
        }
        if (collect3.activeInHierarchy == false)
        {
            collCol3.gameObject.SetActive(true);
        }
        if (collect4.activeInHierarchy == false)
        {
            collCol4.gameObject.SetActive(true);
        }

    }
}
