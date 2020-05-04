/************************************************************************************************
// File Name:   SetBrightness.cs
// Author:      Jamey Colleen
// Description: Contains a function for setting the volume of the game via a slider, interacting
//              with the Mixer.
************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{

    public AudioMixer mixer;

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("vol", Mathf.Log10(sliderValue) * 20);
    }

}
