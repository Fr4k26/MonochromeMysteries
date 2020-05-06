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
