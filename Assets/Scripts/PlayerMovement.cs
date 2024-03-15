using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    public CharacterController characterController;
    public float _gravity = 0.3f;
    public float _playerspeed = 7;
    public float _jumpheight = 3.0f;
    public float _yvelocity = 1.0f;
    private float _timeOnAir = 0.0f;
    private float _gravityScaler = 0.05f;
    private bool jump = false;


    // Start is called before the first frame update
    void Start()
    {
        characterController.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3 (horizontalInput, 0, 0);
        Vector3 velocity = direction * _playerspeed;

        if (characterController.isGrounded == true)
        {
            //Debug.Log("Isgrounded");
            if (Input.GetKeyDown(KeyCode.W))
            {
                _yvelocity = _jumpheight;
                _gravityScaler = 0.15f;
            }
            else
            {
                _yvelocity = -5.0f;
                _gravityScaler = 0.15f;
            }
            _gravity = 0.0f;
            _timeOnAir = 0.0f;
        }
        else
        {
            //Debug.Log("in air");
            _timeOnAir += Time.deltaTime;
            _gravity = _gravity + Time.deltaTime;
            if (_gravity > _gravityScaler) _gravity = _gravityScaler;
            _yvelocity -= _gravity;
            //Debug.Log(_gravity);
        }

        velocity.y = _yvelocity;

        characterController.Move(velocity * Time.deltaTime);

        
    }
}
