using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{

    private float camPosX;
    private float playerPosX;
    private float oldPlayerPosX;
    private float oldCamPosX;
    private float currentYRotation;
    private bool turnedRight = false;
    private bool turnedLeft = false;
    // Start is called before the first frame update
    void Start()
    {
        currentYRotation = transform.rotation.y;
        oldPlayerPosX = transform.parent.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentYRotation = transform.localRotation.y;

        if (transform.parent.position.x > oldPlayerPosX)
        {
            turnedRight = true;
            turnedLeft = false;

        }
        else if (transform.parent.position.x < oldPlayerPosX)
        {
            turnedRight = false;
            turnedLeft = true;

        }
        if (turnedRight)
        {         
                //currentYRotation -= 1;
                transform.rotation = new Quaternion(0, -10f, 0, 0);               
            
        }
        else if (turnedLeft)
        {
            
                //currentYRotation += 1;
                //transform.localRotation = new Quaternion(0, -30f, 0, 0);
            
        }

        oldPlayerPosX = transform.parent.position.x;
    }
}
