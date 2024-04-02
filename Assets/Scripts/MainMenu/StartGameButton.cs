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
    public void PlayGame()
    {
        startGame = transform.Find("Main Menu/Start Game");
        options = transform.Find("Main Menu/Options");
        quitGame = transform.Find("Main Menu/Quit to Menu");
        logo = transform.Find("Logo");
        loadscene = transform.Find("LoadScene");
        prologueText = transform.Find("PrologueText");

        startGame.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        quitGame.gameObject.SetActive(false);
        logo.gameObject.SetActive(false);
        prologueText.gameObject.SetActive(true);
        loadscene.gameObject.SetActive(true);
        
    }
}
