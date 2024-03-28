using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    private bool canFade;
    private Color alphaColor;
    private float timeToFade = 1.0f;
    public Animator vineAnimator;
    void Start()
    {
        alphaColor = gameObject.GetComponentInChildren<MeshRenderer>().material.color;
        alphaColor.a = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void VineActivation(bool sunactivated)
    {
        if (sunactivated)
        {
            //obj.SetActive(true);
            vineAnimator.GetComponent<Animator>().Play("lehdetYlos");
            obj.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            //obj.SetActive(false);
            vineAnimator.GetComponent<Animator>().Play("lehdetAlas");
            obj.GetComponent<BoxCollider>().enabled = false;
        }
        //StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        float timer = 0;
        while (timer < 1)
        {
            gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.Lerp(obj.GetComponentInChildren<MeshRenderer>().material.color, alphaColor, timeToFade * Time.deltaTime);
            timer += Time.deltaTime;
            Debug.Log("In coroutine)");
        }

        yield return null;
    }
}
