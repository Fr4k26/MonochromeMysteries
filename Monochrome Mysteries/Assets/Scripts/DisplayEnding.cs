/************************************************************************************************
// File Name:   DisplayEnding.cs
// Author:      David Suriano
// Description: This script is used to keep track of the appropriate ending text displayed
//              based upon player decisions in the Journal.
************************************************************************************************/

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
