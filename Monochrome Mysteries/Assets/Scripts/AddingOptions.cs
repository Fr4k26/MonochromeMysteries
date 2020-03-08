﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddingOptions : MonoBehaviour
{
    public GameObject addOptions;
    DialgoueManager manager;
    // Start is called before the first frame update

    private void Start()
    {
        manager = FindObjectOfType<DialgoueManager>();
    }

    public void AddOption()
    {
        if (manager.sentences.Count == 0)
        {
            addOptions.SetActive(true);
        }
    }
}
