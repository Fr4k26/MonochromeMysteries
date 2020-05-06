﻿/************************************************************************************************
// File Name:   AddingOptions.cs
// Author:      Adrian Frak
// Description: This script is for managing new choices given to the player in dialogue with
//              different characters, referencing the Dialogue Manager and the Player.
************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddingOptions : MonoBehaviour
{
    public GameObject addOptions;
    DialgoueManager manager;
    CameraController controller;
    // Start is called before the first frame update

    private void Start()
    {
        manager = FindObjectOfType<DialgoueManager>();
        controller = FindObjectOfType<CameraController>();
    }

    //Adds options to the dialogue!
    public void AddOption()
    {
        if (manager.sentences.Count <= 0)
        {
            addOptions.SetActive(true);
        }
    }

    public void AddOptionCam()
    {
        addOptions.SetActive(true);
    }
}
