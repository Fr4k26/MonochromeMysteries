/************************************************************************************************
// File Name:   Transition.cs
// Author:      Jake Hyland
// Description: This script hides some of the loading in the main level with a fade from black.
************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    public float fadingDuration = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        var startPanel = GameObject.Find("Fade-In Panel").GetComponent<CanvasGroup>();
        StartCoroutine(Fade(startPanel, startPanel.alpha, 0));
    }

    IEnumerator Fade(CanvasGroup startPanel, float starting, float end)
    {
        float counter = 0f;

        while (counter < fadingDuration)
        {
            counter += Time.deltaTime;
            startPanel.alpha = Mathf.Lerp(starting, end, counter / fadingDuration);
            yield return null;
        }
    }

}
