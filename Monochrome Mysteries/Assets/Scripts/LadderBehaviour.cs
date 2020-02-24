using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderBehaviour : MonoBehaviour
{

    public GameObject player;
    private bool canClimb = false;
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
        if (canClimb)
        {
            
            if (Input.GetKey(KeyCode.W))
            {
                player.transform.Translate(up * Time.deltaTime * climbSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                canClimb = false;
                player.GetComponent<PlayerController>().canmove = true;
                player.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            canClimb = true;
            player.GetComponent<PlayerController>().canmove = false;
            player.GetComponent<Rigidbody>().useGravity = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            canClimb = false;
            player.GetComponent<PlayerController>().canmove = true;
            player.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
