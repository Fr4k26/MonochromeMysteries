/************************************************************************************************
// File Name:   MouseOn.cs
// Author:      Jake Hyland
// Description: This script is only for making certain any method of going back to the Main Menu
//              scene has no chance of disabling the mouse cursor.
************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
