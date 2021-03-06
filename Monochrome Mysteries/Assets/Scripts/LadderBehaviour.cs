﻿/************************************************************************************************
// File Name:   LadderBehaviour.cs
// Authors:     David Suriano (60%), Jamey Colleen (20%) & Jake Hyland (20%)
// Description: Contains references to the Player in order to allow them to move up and down the
//              ladders (Jamey), the controlling methods for entering and exiting that state (David),
//              as well as play sounds when climbing is taking place (Jake).
************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderBehaviour : MonoBehaviour
{

    public GameObject player;
    public GameObject landing;

    private bool onLadder = false;
    private bool justOnLadder = false;
    private bool justEscaped = false;
    public float climbSpeed = 1;
    private Vector3 up = new Vector3(0, 1, 0);
    private Vector3 down = new Vector3(0, -1, 0);

    public AudioClip[] climbingSounds;
    private AudioSource ladderSource;
    private bool ladderNoise = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        landing = gameObject.transform.GetChild(1).gameObject;
        ladderSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (onLadder)
        {   
            if (Input.GetKey(KeyCode.W))
            {
                player.transform.Translate(up * Time.deltaTime * climbSpeed);
                StartCoroutine(nextRung());
            }
            if (Input.GetKey(KeyCode.S))
            {
                player.transform.Translate(down * Time.deltaTime * climbSpeed);
                StartCoroutine(nextRung());
            }
        }
    }

    private void OnTriggerExit(Collider other)//You have exited the ladder's primary hit box
    {
        if (other.gameObject == player)
        {
            justEscaped = true;
            Invoke("ResetEscape", .1f);
        }
    }

    void ResetEscape()
    {
        justEscaped = false;
    }

    private void OnTriggerEnter(Collider other)//You have entered the ladder's primarily hit box
    {
        if (other.gameObject == player && !onLadder && !justEscaped)
        {
            StickToLadder();
        }
        else if(other.gameObject == player && onLadder && !justEscaped)
        {
            KickOffLadder();
        }
    }

    public void StickToLadder()
    {
        ladderNoise = true;
        onLadder = true;
        justOnLadder = false;

        landing.SetActive(false);

        player.GetComponent<PlayerController>().canClimb = true;
        player.GetComponent<PlayerController>().canmove = false;
        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    public void KickOffLadder()
    {
        ladderNoise = false;
        onLadder = false;
        justOnLadder = true;

        landing.SetActive(true);

        player.GetComponent<PlayerController>().canClimb = false;
        player.GetComponent<PlayerController>().canmove = true;
        player.GetComponent<Rigidbody>().useGravity = true;
    }


    IEnumerator nextRung()
    {
        if (onLadder && ladderNoise == true)
        {
            ladderNoise = false;
            ladderSource.PlayOneShot(climbingSounds[Random.Range(0, climbingSounds.Length)], 0.45f);
            yield return new WaitForSeconds(.5f);
            ladderNoise = true;
        }
    }
}
