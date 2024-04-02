using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DemoEnd : MonoBehaviour
{
    private float alphaValue = 0f;
    public GameObject character;
    bool end = false;
    public float endXCoord;
    Transform endText;
    // Start is called before the first frame update
    void Start()
    {
        endText = transform.Find("endingText");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(character.GetComponent<Transform>().position.x);
        if (character.GetComponent<Transform>().position.x > endXCoord) { end = true; }
    }

    private void FixedUpdate()
    {
        if (end)
        {
            endText.gameObject.SetActive(true);
            var color = this.GetComponent<Image>().color;
            if (color.a < 90)
            {
                alphaValue += 0.001f;
            }
            else if (color.a < 99)
            {
                alphaValue += 0.0001f;
            }
            else
            {
                alphaValue += 0.00001f;
            }
            color.a = alphaValue;
            this.GetComponent<Image>().color = color;

            if (color.a >= 1f)
            {
                StartCoroutine(waitforEnd());
            }
        }
    }

    IEnumerator waitforEnd()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
    }
}
