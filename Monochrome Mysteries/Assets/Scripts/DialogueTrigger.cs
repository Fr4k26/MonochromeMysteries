/************************************************************************************************
// File Name:   DialogueTrigger.cs
// Author:      Adrian Frak 
// Description: Contains the script that triggers the dialogue when the player enters the trigger.
************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public UnityEvent onConvoEnd;
    public bool didIntroEnd;

    public void TriggerDialogue()
    {
      FindObjectOfType<DialgoueManager>().StartDialogue(dialogue);
     // onConvoEnd.Invoke();
      DialgoueManager.currentTrigger = this;
    }

    public void IntroEnd()
    {
        didIntroEnd = true;
    }
}
