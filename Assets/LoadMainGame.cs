using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene()
    {
        SceneManager.LoadScene("Start");
        SceneManager.LoadScene("Foliage", LoadSceneMode.Additive);
        Time.timeScale = 1;
    }
}
