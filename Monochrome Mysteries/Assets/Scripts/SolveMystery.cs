using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SolveMystery : MonoBehaviour
{
    public Dropdown firstDrop;
    public Dropdown secondDrop;
    public Dropdown thirdDrop;

    public Text winText;

    public string firstValue;
    public string secondValue;
    public string thirdValue;

    bool firstCorrect;
    bool secondCorrect;
    bool thirdCorrect;


    public void CheckOptions()
    {
        print("First: " + firstDrop.captionText.text);
        if (firstDrop.captionText.text == firstValue)
        {
            firstCorrect = true;
            Debug.Log("Correct 1");
        }
        else
        {
            firstCorrect = false;
        }

        print("Second: " + secondDrop.captionText.text);
        if (secondDrop.captionText.text == secondValue)
        {
            secondCorrect = true;
            Debug.Log("Correct 2");
        }
        else
        {
            secondCorrect = false;
        }

        print("Third: " + thirdDrop.captionText.text);
        if (thirdDrop.captionText.text == thirdValue)
        {
            thirdCorrect = true;
            Debug.Log("Correct 3");
        }
        else
        {
            thirdCorrect = false;
        }
    }

    public void SolveM()
    {
        if(firstCorrect && secondCorrect && thirdCorrect == true)
        {
            Debug.Log("Solved the Mystery!");
            winText.text = "You have solved the Mystery!";
            winText.gameObject.SetActive(true);
            StartCoroutine(winChange());
        }
    }

    IEnumerator winChange()
    {
        yield return new WaitForSeconds(0.805f);
        SceneManager.LoadScene("Victory");
    }
}
