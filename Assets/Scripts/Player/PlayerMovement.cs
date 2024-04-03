using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    ControllerColliderHit playerCollider;
    public GameObject groundCheck;
    public Animator charaAnimation;
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
    private bool jumpUsed = false;
    private bool jumpPressed = false;
    private bool doublejump = false;
    private bool doublejumpUsed = false;
    private bool directionChanged = false;
    private bool dayChanged = false;
    private bool sunActived = true;
    public bool ceilingHit = false;
    public bool isGrounded = false;
    public bool rockCollision = false;
    public bool checkForGround = false;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource doubleJumpSound;
    [SerializeField] AudioSource landingSound;
    [SerializeField] AudioSource playerWalk;


    // Start is called before the first frame update
    void Start()
    {
        characterController.GetComponent<CharacterController>();
        charaAnimation.GetComponent<Animator>();
        _playerspeedActual = _playerspeed;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (characterController.isGrounded == true)
        {          
            //Debug.Log("Isgrounded");
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                jump = true;
                jumpPressed = true;
            }
            else
            {
                
            }
            _gravity = 0.0f;
            _timeOnAir = 0.0f;

        }
        else
        {
            if (checkForGround == false)
            {
                if (doublejumpUsed == false && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
                {
                    doublejump = true;
                }
                else
                {
                    jump = false;
                }
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (jumpPressed == false)
                {
                    jump = true;
                    jumpPressed = true;
                }
            }
            else
            {
                //jump = false;
            }
        }           
    }

    private void FixedUpdate()
    {
        
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        
        if (transform.position.x > oldXPosition)
        {
            positiveXMovement = true;
            groundCheck.transform.localPosition = new Vector3(-0.4f, -0.1f, 0f);
        }
        else if (transform.position.x < oldXPosition)
        {
            negativeXMovement = true;
            groundCheck.transform.localPosition = new Vector3(0.4f, -0.1f, 0f);
        }

        if (Input.GetButton("Horizontal") && characterController.isGrounded == true)
        {
            if (playerWalk.isPlaying == false)
            {
                playerWalk.time = 0.1f;
                playerWalk.Play();
            }

            if (playerWalk.time > 0.6f)
            {
                playerWalk.Stop();
            }
        }
        else
        {
            if (playerWalk.time > 0.6f)
            {
                playerWalk.Stop();
            }
        }


        if (jumpPressed)
        {
           // Debug.Log("Jump");
            charaAnimation.GetComponent<Animator>().Play("playerJump");
        }
        else if (Input.GetButton("Horizontal"))
        {
            if (characterController.isGrounded == true && rockCollision == true)
            {
                charaAnimation.GetComponent<Animator>().Play("playerPush");
            }
            else
            {
                //Debug.Log("Walk");
                if (charaAnimation.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("playerJump") == false)
                {
                    charaAnimation.GetComponent<Animator>().Play("playerWalk");
                }
                else if (charaAnimation.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > charaAnimation.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length)
                {
                    charaAnimation.GetComponent<Animator>().Play("playerWalk");
                }
            }
        }
        else
        {
            //Debug.Log("not walking");
            if (characterController.isGrounded == true)
            {
                charaAnimation.GetComponent<Animator>().Play("playerIdle");
            }
        }

        


        if (characterController.isGrounded == true)
        {
            if (jump)
            {
                _yvelocity = _jumpheight;
                _gravityScaler = 0.25f;
                jumpSound.time = 0.175f;
                jumpSound.Play();
                jumpUsed = true;
            }
            else
            {
                _yvelocity = -1.0f;
                _gravityScaler = 0.25f;
                if (jumpUsed || doublejumpUsed)
                {
                    landingSound.Play();
                }
                jumpUsed = false;
            }

            if (doublejumpUsed)
            {
                doublejumpUsed = false;               
            }

            positiveXMovement = false;
            negativeXMovement = false;
            directionChanged = false;
            _playerspeedActual = _playerspeed;

            jumpPressed = false;

        }
        else
        {
            if (positiveXMovement && negativeXMovement && !directionChanged)
            {
                _playerspeedActual = _playerspeedActual / 2;
                directionChanged = true;
            }
            if (jump)
            {
                _yvelocity = _jumpheight;
                _gravityScaler = 0.25f;
                jumpSound.time = 0.175f;
                jumpSound.Play();
            }
            if (doublejump)
            {
                float playerspeedScale = _yvelocity / 8;
                if ( playerspeedScale > 0)
                {
                    _playerspeedActual += playerspeedScale + 2;
                }
                else
                {
                    _playerspeedActual += 2;
                }
                _yvelocity += 15;
                if (_yvelocity > 12) { _yvelocity = 12; }
                else if (_yvelocity < 8) { _yvelocity = 12; }
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
                _gravityScaler = 0.25f;
                doublejumpUsed = true;
                doublejump = false;
                doubleJumpSound.time = 0.175f;
                doubleJumpSound.Play();
            }

            //Debug.Log("in air");
            _timeOnAir += Time.deltaTime;
            _gravity = _gravity + Time.deltaTime;
            if (_gravity > _gravityScaler) _gravity = _gravityScaler;
            _yvelocity -= _gravity;

            if ((characterController.collisionFlags & CollisionFlags.Above) != 0)
            {
                if (_yvelocity > 0)
                {
                    _yvelocity = -2;
                }
            }

            if (_yvelocity < -25) { _yvelocity = -25; }
        }

        var ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 0.3f))
        {
            if (hit.collider.tag == "Ground")
            {
                isGrounded = true;
            }
        }
        else
        {
            isGrounded = false;
        }

        Vector3 velocity = direction * _playerspeedActual;

        velocity.y = _yvelocity;

        oldXPosition = transform.position.x;

        if (transform.position.z != 0)
        {
            Debug.Log("Moved in Z coordinate!");
            Vector3 pos = transform.position;
            pos.z = 0.00f;
            transform.position = pos;
        }

        characterController.Move(velocity * Time.deltaTime);       
    }
}
