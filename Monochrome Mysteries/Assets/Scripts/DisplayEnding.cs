using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayEnding : MonoBehaviour
{
     private string winText;
    void Start()
    {
        winText = PlayerPrefs.GetString("endingText");
        gameObject.GetComponent<Text>().text = winText;
    }
}
