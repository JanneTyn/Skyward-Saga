using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunAndMoonPosition : MonoBehaviour
{
    Transform posX;

    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        posX = player.transform;

        transform.position = new Vector3(posX.position.x, transform.position.y, transform.position.z);
    }
}
