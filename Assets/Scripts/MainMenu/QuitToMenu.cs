using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMenu : MonoBehaviour
{
    
    public void QuitMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
