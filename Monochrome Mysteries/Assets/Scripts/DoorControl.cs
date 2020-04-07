using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{

    public GameObject theDoor; //the specific door that is controlled by this script
    public bool doorOpen = false; //this bool will simply allow the player to walk through the wall the represents the door
    public AudioSource doorNoise;
    public AudioClip open;
    public AudioClip close;
    public AudioClip locked;
    public GameObject doorLocked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && doorOpen)
        {
            doorNoise.PlayOneShot(open);
            theDoor.SetActive(false);
        }
        else if (other.tag == "Player" && !doorOpen)
        {
            doorNoise.PlayOneShot(locked);
            doorLocked.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            doorNoise.PlayOneShot(close);
            theDoor.SetActive(true);
            doorLocked.SetActive(false);
        }
    }

    public void OpenDoor()
    {
        doorOpen = true;
    }
}
