using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlanes : MonoBehaviour
{

    private Transform respawnPoint;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = GameObject.Find("RespawnPoint").GetComponent<Transform>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("collide");
            playerTransform.transform.position = respawnPoint.transform.position;
        }
    }
}
