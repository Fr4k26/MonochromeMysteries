using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    public void openGameScreen()
    {
        SceneManager.LoadScene("Verticle Slice");
    }

    public void openMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void openHowToPlay()
    {
        SceneManager.LoadScene("How to Play Scene");
    }

    public void openCredits()
    {
        SceneManager.LoadScene("Credits Scene");
    }

    public void endGame()
    {
        Application.Quit();
    }
}
