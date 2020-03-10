using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{

    public AudioSource buttonSound;
    public AudioClip[] menuFeedback;
    private int menuChoice;

    void start()
    {
        menuChoice = 0;
    }

    public void openGameScreen()
    {
        buttonSound.PlayOneShot(menuFeedback[0]);
        menuChoice = 1;
        StartCoroutine(soundWait());
    }

    public void openMainMenu()
    {
        buttonSound.PlayOneShot(menuFeedback[1]);
        menuChoice = 2;
        StartCoroutine(soundWait());
    }

    public void openHowToPlay()
    {
        buttonSound.PlayOneShot(menuFeedback[0]);
        menuChoice = 3;
        StartCoroutine(soundWait());
    }

    public void openCredits()
    {
        buttonSound.PlayOneShot(menuFeedback[0]);
        menuChoice = 4;
        StartCoroutine(soundWait());
    }

    public void endGame()
    {
        buttonSound.PlayOneShot(menuFeedback[1]);
        menuChoice = 5;
        StartCoroutine(soundWait());
    }

    IEnumerator soundWait()
    {
        yield return new WaitForSeconds(1.000f);
        if (menuChoice == 1)
        {
            SceneManager.LoadScene("Old_Vert_Slice");
        }
        if (menuChoice == 2)
        {
            SceneManager.LoadScene("Main Menu");
        }
        if (menuChoice == 3)
        {
            SceneManager.LoadScene("How to Play Scene");
        }
        if (menuChoice == 4)
        {
            SceneManager.LoadScene("Credits Scene");
        }
        if (menuChoice == 5)
        {
            Application.Quit();
        }
    }
}
