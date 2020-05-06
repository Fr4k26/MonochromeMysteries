/************************************************************************************************
// File Name:   MouseOn.cs
// Author:      Jake Hyland
// Description: This script is only for making certain any method of going back to the Main Menu
//              scene has no chance of disabling the mouse cursor. It also destroys the Music
//              when the proper game is started.
************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MouseOn : MonoBehaviour
{
    public GameObject oldMusic;
    private string sceneName;
    private bool silencedMusic = false;

    void Start()
    {
        silencedMusic = false;
    }

    void Update()
    {
        if (silencedMusic == false)
        {
            GameObject oldMusic = GameObject.FindGameObjectWithTag("Music Source");
            sceneName = SceneManager.GetActiveScene().name;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            if (sceneName == "Beta Level")
            {
                Destroy(oldMusic);
                silencedMusic = true;
            }
        }
    }
}
