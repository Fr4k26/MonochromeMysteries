using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public UnityEvent onConvoEnd;

    public void TriggerDialogue()
    {
      FindObjectOfType<DialgoueManager>().StartDialogue(dialogue);
     // onConvoEnd.Invoke();
      DialgoueManager.currentTrigger = this;
    }
}
