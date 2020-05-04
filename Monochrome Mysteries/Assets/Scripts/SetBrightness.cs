/************************************************************************************************
// File Name:   SetBrightness.cs
// Author:      Jamey Colleen
// Description: Contains a function for setting the brightness of the game via a slider.
************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBrightness : MonoBehaviour
{

    public void SetBright(float sliderValue)
    {
        RenderSettings.ambientLight = new Color(sliderValue, sliderValue, sliderValue, 1);
    }

}
