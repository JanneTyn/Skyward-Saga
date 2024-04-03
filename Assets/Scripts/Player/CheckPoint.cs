using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{

    [SerializeField] GameObject player;

    [SerializeField] List<GameObject> checkPoints;

    [SerializeField] Vector3 vectorPoint;

    [SerializeField] float dead;
    [SerializeField] float dead2;

    public CharacterController controller;
    public Image img;
    bool deadCheck = false;
    private AudioSource checkpointSound;

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
            StartCoroutine(FadeCanvas(true));
        }
        if (player.transform.position.y > -dead2)
        {
            controller.enabled = false;
            player.transform.position = vectorPoint;
            controller.enabled = true;
            StartCoroutine(FadeCanvas(true));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            vectorPoint = player.transform.position;

            // play animaatio kivelle?
            Debug.Log("Checkpoint");

            if (gameObject.GetComponent<AudioSource>().isPlaying == false && deadCheck == false)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
            else
            {
                deadCheck = true;
            }
            
        }
        
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            controller.enabled = false;
            player.transform.position = vectorPoint;
            controller.enabled = true;
            Debug.Log("kuolit");
            StartCoroutine(FadeCanvas(true));
            deadCheck = true;
        }
    }
    IEnumerator FadeCanvas(bool fadeAway)
    {
       
        if (fadeAway)
        {
            for (float i = 2; i >= 0; i -= Time.deltaTime)
            {
               
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        else
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }
}
