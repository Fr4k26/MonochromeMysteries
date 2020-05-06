// Author:      Adrian Frak
// Description: This script is for managing the basic instantiation of dialogue in a character's
//              animations.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introCheck : MonoBehaviour
{
    public bool hasIntroduced = false;
    public DialogueTrigger firstTime;
    public DialogueTrigger otherTime;

   public void checkIntro()
    {
        if(hasIntroduced == true)
        {
            otherTime.TriggerDialogue();
        }
        else
        {
            firstTime.TriggerDialogue();
            hasIntroduced = true;
            Debug.Log("could you maybe turn the fuck on thank you");
        }
    }


}
