using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraPosition : MonoBehaviour
{
    // Start is called before the first frame update

    private float camPosX;
    private float playerPosX;
    private float oldPlayerPosX;
    private float oldCamPosX;
    private bool turnedRight = false;
    private bool turnedLeft = false;
    void Start()
    {
        oldCamPosX = transform.position.x;
        oldPlayerPosX = transform.parent.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
            if (transform.localPosition.x < 4)
            {
                transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
            }
        }
        else if (turnedLeft)
        {
            if (transform.localPosition.x > -4)
            {
                transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z);
            }
        }

        oldPlayerPosX = transform.parent.position.x;
    }
}
