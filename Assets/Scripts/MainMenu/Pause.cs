using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
            
    }
   

    
}
