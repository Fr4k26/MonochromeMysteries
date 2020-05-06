/************************************************************************************************
// File Name:   ButtonCheck.cs
// Author:      Adrian Frak
// Description: This script is for interfacing with the Dialogue Manger in order to properly
//              end conversations between characters and the player.
************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCheck : MonoBehaviour
{
    DialgoueManager manager;
    Button endButton;

    void Start()
    {
        manager = FindObjectOfType<DialgoueManager>();
    }

    public void EndConvo()
    {
        manager.gameObject.SetActive(false);
    }
}
