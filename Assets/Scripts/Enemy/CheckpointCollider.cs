using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Collider>().enabled = false;
    } 
}
