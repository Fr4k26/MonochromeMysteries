/************************************************************************************************
// File Name:   Dialogue.cs
// Author:      Adrian Frak
// Description: This script is for managing the basic instantiation of dialogue in a character's
//              UI display and controlling the size for each display.
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
