using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    private Transform startGame;
    private Transform options;
    private Transform quitGame;
    private Transform logo;
    private Transform loadscene;
    private Transform prologueText;
    private Transform backgroundAlpha;
    private Transform credits;
    public void PlayGame()
    {
        startGame = transform.Find("Main Menu/Start Game");
        options = transform.Find("Main Menu/Options");
        quitGame = transform.Find("Main Menu/Quit to Menu");
        logo = transform.Find("Logo");
        backgroundAlpha = transform.Find("backgroundAlpha");
        credits = transform.Find("Main Menu/Credits");

        startGame.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        quitGame.gameObject.SetActive(false);
        logo.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        backgroundAlpha.gameObject.SetActive(true);
        
    }
}
