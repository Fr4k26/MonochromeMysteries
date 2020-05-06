/************************************************************************************************
// File Name:   LadderBehaviour.cs
// Authors:      Jamey Colleen (83%) & Jake Hyland (17%)
// Description: Contains references to the Player in order to allow them to move up and down the
//              ladders (Jamey), as well as play sounds when climbing is taking place (Jake).
************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderBehaviour : MonoBehaviour
{

    public GameObject player;
    public float climbSpeed = 1;
    private Vector3 up = new Vector3(0, 1, 0);
    private Vector3 down = new Vector3(0, -1, 0);

    public AudioClip[] climbingSounds;
    private AudioSource ladderSource;
    private bool onLadder = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ladderSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().canClimb)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            onLadder = true;
            player.GetComponent<PlayerController>().canClimb = true;
            player.GetComponent<PlayerController>().canmove = false;
            player.GetComponent<Rigidbody>().useGravity = false;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            onLadder = false;
            player.GetComponent<PlayerController>().canClimb = false;
            player.GetComponent<PlayerController>().canmove = true;
            player.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    IEnumerator nextRung()
    {
        if (onLadder == true)
        {
            ladderSource.PlayOneShot(climbingSounds[Random.Range(0, climbingSounds.Length)], 0.55f);
            onLadder = false;
            yield return new WaitForSeconds(0.555f);
            onLadder = true;
        }
    }
}
