
/************************************************************************************************
// File Name:   ScrollToggle.cs
// Author:      David Suriano
// Description: This script is used to control the scrolling text during conversations with all
//              the characters. Due to hardware issues, some computers display text at an
//              annoyingly slow speed, so an optional toggle will allow them to avoid this on
//              slower machines.
************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollToggle : MonoBehaviour
{
    Toggle toggle;
    private void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.isOn = (PlayerPrefs.GetInt("displayAll") == 0);
    }

    public void ToggleText(bool value)
    {
        PlayerPrefs.SetInt("displayAll", (value) ? 0 : 1);
    }
}
