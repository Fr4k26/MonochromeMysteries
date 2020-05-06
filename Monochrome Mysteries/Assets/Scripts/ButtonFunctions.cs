using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{

    public AudioSource buttonSound;
    public AudioClip[] menuFeedback;
    private int menuChoice;
    public Text startText;
    public float fadingDuration = 0.8f;
    private bool gameStart = false;

    void start()
    {
        menuChoice = 0;
    }

    public void openGameScreen()
    {
        if (gameStart == false)
        {
            buttonSound.PlayOneShot(menuFeedback[0]);
            menuChoice = 1;
            StartCoroutine(soundWait());
        }
    }

    public void openMainMenu()
    {
        if (gameStart == false)
        {
            buttonSound.PlayOneShot(menuFeedback[1]);
            menuChoice = 2;
            StartCoroutine(soundWait());
        }
    }

    public void openHowToPlay()
    {
        if (gameStart == false)
        {
            buttonSound.PlayOneShot(menuFeedback[0]);
            menuChoice = 3;
            StartCoroutine(soundWait());
        }
    }

    public void openCredits()
    {
        if (gameStart == false)
        {
            buttonSound.PlayOneShot(menuFeedback[0]);
            menuChoice = 4;
            StartCoroutine(soundWait());
        }
    }

    public void endGame()
    {
        if (gameStart == false)
        {
            buttonSound.PlayOneShot(menuFeedback[1]);
            menuChoice = 5;
            StartCoroutine(soundWait());
        }
    }

    public void openBonusScreen()
    {
        if (gameStart == false)
        {
            var panelFader = GameObject.Find("Fade Transition").GetComponent<CanvasGroup>();
            gameStart = true;
            StartCoroutine(Fadein(panelFader, panelFader.alpha, 1));
            buttonSound.PlayOneShot(menuFeedback[0]);
            menuChoice = 6;
        }
    }

    IEnumerator soundWait()
    {
        yield return new WaitForSeconds(0.350f);
        if (menuChoice == 1)
        {
            SceneManager.LoadScene("Verticle Slice");
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

    IEnumerator LoadAsyncScene()
    {
        var panelFader2 = GameObject.Find("Fade To Black").GetComponent<CanvasGroup>();
        // Loads the Scene in the background as the current Scene runs.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Beta Level");
        asyncLoad.allowSceneActivation = false;

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            // Check if the load has finished
            if (asyncLoad.progress >= 0.9f)
            {
                //Change the Text to show the Scene is ready
                startText.text = "Press Space to begin.";
                //Wait to you press the space key to activate the Scene
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //Activate the Scene
                    StartCoroutine(BlackFade(panelFader2, panelFader2.alpha, 1));
                    yield return new WaitForSeconds(0.850f);
                    asyncLoad.allowSceneActivation = true;
                }

            }
            yield return null;
        }
    }


    IEnumerator Fadein(CanvasGroup panelFader, float start, float end)
    {
        float counter = 0f;

        while(counter < fadingDuration)
        {
            counter += Time.deltaTime;
            panelFader.alpha = Mathf.Lerp(start, end, counter / fadingDuration);
            yield return null;
        }
        yield return new WaitForSeconds(0.250f);
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator BlackFade(CanvasGroup panelFader2, float start, float end)
    {
        float counter = 0f;

        while (counter < fadingDuration)
        {
            counter += Time.deltaTime;
            panelFader2.alpha = Mathf.Lerp(start, end, counter / fadingDuration);
            yield return null;
        }
    }
}
