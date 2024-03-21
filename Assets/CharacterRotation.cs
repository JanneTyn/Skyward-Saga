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
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        currentYRotation = transform.rotation.y;
        oldPlayerPosX = player.transform.parent.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentYRotation = transform.localRotation.y;

        if (player.transform.parent.position.x > oldPlayerPosX)
        {
            turnedRight = true;
            turnedLeft = false;

        }
        else if (player.transform.parent.position.x < oldPlayerPosX)
        {
            turnedRight = false;
            turnedLeft = true;

        }
        if (turnedRight)
        {
            //currentYRotation -= 1;
            if (player.transform.localEulerAngles.y > 210f)
            {
                Debug.Log(player.transform.localEulerAngles.y);
                player.transform.Rotate(0, -1, 0);
            }
            
        }
        else if (turnedLeft)
        {
            if (player.transform.localEulerAngles.y < 330f)
            {
                player.transform.Rotate(0, 1, 0);
            }

        }

        oldPlayerPosX = player.transform.parent.position.x;
    }
}
