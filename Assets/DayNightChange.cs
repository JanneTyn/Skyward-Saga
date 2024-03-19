using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DayNightChange : MonoBehaviour
{

    public Image sunmoonTexture;
    public Sprite sunTexture;
    public Sprite moonTexture;
    // Start is called before the first frame update
    void Start()
    {
        sunmoonTexture = GetComponent<Image>();
        sunmoonTexture.sprite = sunTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DayChange(bool sunActive)
    {       
        if (sunActive)
        {
            sunmoonTexture.sprite = sunTexture;
        }
        else
        {
            sunmoonTexture.sprite = moonTexture;
        }
    }
}
