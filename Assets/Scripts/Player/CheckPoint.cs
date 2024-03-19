using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    [SerializeField] GameObject player;

    [SerializeField] List<GameObject> checkPoints;

    [SerializeField] Vector3 vectorPoint;

    [SerializeField] float dead;
    public CharacterController controller;

    void Start()
    {
        controller = player.GetComponent<CharacterController>();
    }
    void Update()
    {
        if (player.transform.position.y < -dead)
        {
            controller.enabled = false;
            player.transform.position = vectorPoint;
            controller.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        vectorPoint = player.transform.position;
       // play animaatio kivelle?
        Debug.Log("Checkpoint");
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            controller.enabled = false;
            player.transform.position = vectorPoint;
            controller.enabled = true;
            Debug.Log("kuolit");
        }
    }
}
