using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressureTileCenterPointCollision : MonoBehaviour
{

    public GameObject vinePlatform;
    public Animator vineAnimator;
    [SerializeField] AudioSource rockonTile;
    [SerializeField] GameObject rockdoor;
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
            rockonTile.time = 0.2f;
            rockonTile.Play();
            StartCoroutine(doorDown());
            //vinePlatform.SetActive(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "RollingRock")
        {
            Debug.Log("Kivi poissa");
            vineAnimator.GetComponent<Animator>().Play("lehdetYlos");
            StartCoroutine(doorUp());
            //vinePlatform.SetActive(true);
        }
    }

    IEnumerator doorDown()
    {
        for (float i = 0; i > -6f; i = i - 0.01f)
        {
            Vector3 doorlocation = rockdoor.transform.position;
            doorlocation.y = i;
            rockdoor.transform.position = doorlocation;
            yield return null;
        }      
    }

    IEnumerator doorUp()
    {
        for (float i = -6f; i < 0; i = i + 0.01f)
        {
            Vector3 doorlocation = rockdoor.transform.position;
            doorlocation.y = i;
            rockdoor.transform.position = doorlocation;
            yield return null;
        }
    }
}
