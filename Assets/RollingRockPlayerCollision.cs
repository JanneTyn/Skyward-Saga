using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingRockPlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerMovement playerMovement;
    private Vector3 spawnPoint;
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        spawnPoint = this.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.z != 0f)
        {
            Vector3 pos = transform.position;
            pos.z = 0f;
            transform.position = pos;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.transform.tag == "Player")
        {
            //playerMovement.rockCollision = true;
            //Debug.Log("Player hits ball");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            //playerMovement.rockCollision = false;
            //Debug.Log("Player no longer hitting ball");
        }
    }

    public void ResetRocks()
    {
        transform.localPosition = spawnPoint;
    }
}
