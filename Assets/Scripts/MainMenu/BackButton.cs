using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject optMenu;
    public GameObject mainMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optMenu.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(true);
        }
    }
}
