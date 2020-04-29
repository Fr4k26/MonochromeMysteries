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

    public string[] firstSolution = new string[3];
    public string[] secondSolution = new string[3];
    public string[] thirdSolution = new string[3];
    public string[] fourthSolution = new string[3];
    public string[] fifthSolution = new string[1];

    public void CheckOptions()
    {
        if (firstDrop.captionText.text == firstSolution[0] && secondDrop.captionText.text == firstSolution[1] && thirdDrop.captionText.text == firstSolution[2])
        {
            print("Femme Fatale True Ending");
        }
        else if (firstDrop.captionText.text == secondSolution[0] && secondDrop.captionText.text == secondSolution[1] && thirdDrop.captionText.text == secondSolution[2])
        {
            print("Businessman True Ending");
        }
        else if (firstDrop.captionText.text == thirdSolution[0] && secondDrop.captionText.text == thirdSolution[1] && thirdDrop.captionText.text == thirdSolution[2])
        {
            print("Mobster True Ending");
        }
        else if (firstDrop.captionText.text == fourthSolution[0] && thirdDrop.captionText.text == fourthSolution[2]) //Doesn't matter what gun the Paperboy used
        {
            print("Paperboy True Ending");
        }
        else if (firstDrop.captionText.text == firstSolution[0])
        {
            print("Femme Fatale Untrue Ending");
        }
        else if (firstDrop.captionText.text == secondSolution[0])
        {
            print("Businessman Untrue Ending");
        }
        else if (firstDrop.captionText.text == thirdSolution[0])
        {
            print("Mobster Untrue Ending");
        }
        else if (firstDrop.captionText.text == fourthSolution[0])
        {
            print("Paperboy Untrue Ending");
        }
        else if (firstDrop.captionText.text == fifthSolution[0])
        {
            print("Suicide Ending");
        }
        else
        {
            print("Incomplete Mystery");
        }

    }

    public void SolveM()
    {
            Debug.Log("Solved the Mystery!");
            //winText.text = "You have solved the Mystery!";
            //winText.gameObject.SetActive(true);
            StartCoroutine(winChange());
    }

    IEnumerator winChange()
    {
        yield return new WaitForSeconds(0.805f);
        SceneManager.LoadScene("Victory");
    }
}
