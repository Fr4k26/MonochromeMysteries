using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFader : MonoBehaviour
{

    public AudioSource characterMusic;
    public AudioSource sceneMusic;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            characterMusic.volume = characterMusic.volume + 0.25f;
            sceneMusic.volume = sceneMusic.volume - 0.45f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            characterMusic.volume = characterMusic.volume - 0.25f;
            sceneMusic.volume = sceneMusic.volume + 0.45f;
        }
    }
}
