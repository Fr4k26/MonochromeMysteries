﻿/************************************************************************************************
// File Name:   CutDialogue.cs
// Authors:     David Suriano
// Description: Run via buttons, makes sure that if you end a conversation you can move again
//              and that all animations stop.
************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutDialogue : MonoBehaviour
{
    DialgoueManager diagMan;
    PlayerController playerController;


    void Start()
    {
        diagMan = FindObjectOfType<DialgoueManager>();
        playerController = FindObjectOfType<PlayerController>();
    }

    public void DialogueCut()
    {
        diagMan.paperTalking.SetBool("isTalking", false);
        diagMan.femTalking.SetBool("isTalking", false);
        diagMan.mobTalking.SetBool("isTalking", false);
        diagMan.manTalking.SetBool("isTalking", false);

        playerController.canmove = true;
    }
}
