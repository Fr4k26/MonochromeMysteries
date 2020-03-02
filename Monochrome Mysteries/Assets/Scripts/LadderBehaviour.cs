using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderBehaviour : MonoBehaviour
{

    public GameObject player;
    public float climbSpeed = 1;
    private Vector3 up = new Vector3(0, 1, 0);
    private Vector3 down = new Vector3(0, -1, 0);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().canClimb)
        {
            
            if (Input.GetKey(KeyCode.W))
            {
                player.transform.Translate(up * Time.deltaTime * climbSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                player.transform.Translate(down * Time.deltaTime * climbSpeed);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
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
            player.GetComponent<PlayerController>().canClimb = false;
            player.GetComponent<PlayerController>().canmove = true;
            player.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
