using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolveMystery : MonoBehaviour
{
    public Dropdown firstDrop;
    public Dropdown secondDrop;
    public Dropdown thirdDrop;

    public Text winText;

    public int firstValue;
    public int secondValue;
    public int thirdValue;

    bool firstCorrect;
    bool secondCorrect;
    bool thirdCorrect;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }



    public void CheckOptions()
    {
        if(firstDrop.value == firstValue)
        {
            firstCorrect = true;
            Debug.Log("Correct!");
        }
        else
        {
            firstCorrect = false;
        }

        if (secondDrop.value == secondValue)
        {
            secondCorrect = true;
            Debug.Log("Correct");
        }
        else
        {
            secondCorrect = false;
        }

        if (thirdDrop.value == thirdValue)
        {
            thirdCorrect = true;
            Debug.Log(thirdCorrect);
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
        }
    }
}
