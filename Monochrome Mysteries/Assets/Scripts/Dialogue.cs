/************************************************************************************************
// File Name:   Dialogue.cs
// Author:      Adrian Frak 
// Description: Contains the script of how to write dialogue within the hierarchy for Unity, which
                contains the dialogue for the game.
************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;
}
