using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    public CharacterController characterController;
    public float _gravity = 0.3f;
    public float _playerspeedActual = 10;
    public float _playerspeed = 10;
    public float _jumpheight = 3.0f;
    public float _yvelocity = 1.0f;
    private float _timeOnAir = 0.0f;
    private float _gravityScaler = 0.05f;
    private float horizontalInput = 0.05f;
    private float oldXPosition = 0;
    private bool positiveXMovement = false;
    private bool negativeXMovement = false;
    private bool jump = false;
    private bool doublejump = false;
    private bool doublejumpUsed = false;
    private bool directionChanged = false;


    // Start is called before the first frame update
    void Start()
    {
        characterController.GetComponent<CharacterController>();
        _playerspeedActual = _playerspeed;
    }

    // Update is called once per frame
    void Update()
    {


        horizontalInput = Input.GetAxis("Horizontal");

        if (characterController.isGrounded == true)
        {
            //Debug.Log("Isgrounded");
            if (Input.GetKey(KeyCode.W))
            {
                jump = true;              
            }
            else
            {
                
            }
            _gravity = 0.0f;
            _timeOnAir = 0.0f;

        }
        else
        {
            jump = false;
            if (doublejumpUsed == false && Input.GetKeyDown(KeyCode.W))
            {
                doublejump = true;
            }           
        }           
    }

    private void FixedUpdate()
    {

        
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        
        if (transform.position.x > oldXPosition)
        {
            positiveXMovement = true;
        }
        else if (transform.position.x < oldXPosition)
        {
            negativeXMovement = true;
        }

        if (characterController.isGrounded == true)
        {
            if (jump)
            {
                _yvelocity = _jumpheight;
                _gravityScaler = 0.5f;
            }
            else
            {
                _yvelocity = -5.0f;
                _gravityScaler = 0.5f;
            }

            if (doublejumpUsed)
            {
                doublejumpUsed = false;
                
            }

            positiveXMovement = false;
            negativeXMovement = false;
            directionChanged = false;
            _playerspeedActual = _playerspeed;

        }
        else
        {
            if (positiveXMovement && negativeXMovement && !directionChanged)
            {
                _playerspeedActual = _playerspeedActual / 2;
                directionChanged = true;
            }
            if (doublejump)
            {
                float playerspeedScale = _yvelocity / 4;
                if ( playerspeedScale > 0)
                {
                    _playerspeedActual += playerspeedScale + 2;
                }
                else
                {
                    _playerspeedActual += 2;
                }
                _yvelocity += 10;
                if (_yvelocity > 7) { _yvelocity = 7; }
                else if (_yvelocity < 5) { _yvelocity = 5; }
                /*
                if (_yvelocity > 0)
                {
                    _yvelocity = _yvelocity + 10;
                    if (_yvelocity > 11) { _yvelocity = 11; }
                }
                else
                {
                    _yvelocity = _jumpheight;
                } */
                _gravityScaler = 0.5f;
                doublejumpUsed = true;
                doublejump = false;
            }

            //Debug.Log("in air");
            _timeOnAir += Time.deltaTime;
            _gravity = _gravity + Time.deltaTime;
            if (_gravity > _gravityScaler) _gravity = _gravityScaler;
            _yvelocity -= _gravity;
            //Debug.Log(_gravity);
        }

        Vector3 velocity = direction * _playerspeedActual;

        velocity.y = _yvelocity;

        oldXPosition = transform.position.x;

        characterController.Move(velocity * Time.deltaTime);

        
    }
}
