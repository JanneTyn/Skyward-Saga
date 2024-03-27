using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    private PlayerMovement playermovement;

    [SerializeField]
    private float forceMagnitude;
    private bool grounded = false;
    // Start is called before the first frame update
    void Start()
    {
        playermovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        Rigidbody rigidbody = hit.collider.attachedRigidbody;
        if (playermovement.isGrounded)
        {
            if (rigidbody != null)
            {
                Vector3 forcedirection = hit.gameObject.transform.position - transform.position;
                
                forcedirection.y = 0;
                forcedirection.Normalize();
                Debug.Log(forcedirection);

                //rigidbody.AddForceAtPosition(forcedirection * forceMagnitude, transform.position, ForceMode.Impulse);
                //rigidbody.AddRelativeForce(forcedirection * forceMagnitude, ForceMode.Impulse);
                //rigidbody.AddForce(forcedirection * forceMagnitude, ForceMode.Force);
                rigidbody.velocity = forcedirection * forceMagnitude;
            }
        }                      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            grounded = true;
            Debug.Log("groundedd");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            grounded = false;
        }
    }

}
