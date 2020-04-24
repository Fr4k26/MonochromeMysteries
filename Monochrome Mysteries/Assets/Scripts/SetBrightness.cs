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
