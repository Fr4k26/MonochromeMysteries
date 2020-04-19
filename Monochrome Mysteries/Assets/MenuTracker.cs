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
