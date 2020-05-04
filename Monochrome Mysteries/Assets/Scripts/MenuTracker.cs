/************************************************************************************************
// File Name:   GameplayMusic.cs
// Author:      Jake Hyland
// Description: Acts as a conditional to MusicTracker.cs that will remove the Main Menu Music
//              from the gameplay scene.
************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMusic : MonoBehaviour
{
    private GameObject oldMusic;

    void Awake()  //Finds and destroys the music from the Main Menu as soon as seen is loaded.
    {
        GameObject oldMusic = GameObject.FindGameObjectWithTag("Music Source");
        Destroy(oldMusic);
    }
}
