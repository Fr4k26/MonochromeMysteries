/************************************************************************************************
// File Name:   AddingOptions.cs
// Author:      Adrian Frak and David Suriano
// Description: Contains the functions to be able to add dialogue options for the NPC's as well as adding dialogue options 
                when the player has taken a picture of something.
************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddingOptions : MonoBehaviour
{
    public GameObject addOptions;
    DialgoueManager manager;
    DialogueTrigger trigger;
    CameraController controller;
    // Start is called before the first frame update

    private void Start()
    {
        manager = FindObjectOfType<DialgoueManager>();
        controller = FindObjectOfType<CameraController>();
        trigger = FindObjectOfType<DialogueTrigger>();
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
