using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public GameObject pauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ResumeGame()
    {

        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;

    }
}
