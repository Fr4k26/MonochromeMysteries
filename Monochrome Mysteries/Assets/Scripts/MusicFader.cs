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
            characterMusic.volume = characterMusic.volume + 0.2f;
            sceneMusic.volume = sceneMusic.volume - 0.4f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            characterMusic.volume = characterMusic.volume - 0.2f;
            sceneMusic.volume = sceneMusic.volume + 0.4f;
        }
    }
}
