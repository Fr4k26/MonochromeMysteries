﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	PlayerController playerController;
    public float walkSpeed;
	public float sprintSpeed;
	private float moveSpeed;
    Rigidbody playerRB;
	float distToGround = 2f;
	public float jumpSpeed;
    float lastYPos;

    // Min and max values for player position -- use for boundaries regarding where you want the player to go.
    public float xMin, xMax, zMin, zMax;

    // Assign private variable
    private void Start()
	{
		moveSpeed = walkSpeed;
        //stateSwap = FindObjectOfType<StateSwap>();
        playerRB = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
		playerController = GetComponent<PlayerController>();
        lastYPos = GetComponent<Rigidbody>().transform.position.y;
    }
	
    // Handle frame-based events
    void Update()
    {
        Move();
        //test
		//Jump
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
		{
			playerRB.velocity = new Vector3(0f, jumpSpeed, 0f);
		}
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			moveSpeed = sprintSpeed;
 		}
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			moveSpeed = walkSpeed;
		}

        //Vertical limits
        if (isGrounded())
        {
            lastYPos = transform.position.y;
        }
        else if (transform.position.y >= lastYPos + 3)
        {
            playerRB.velocity = new Vector3(playerRB.velocity.x, playerRB.velocity.y/1.75f, playerRB.velocity.z);
        }
	}

	bool isGrounded()
	{
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}
	// Handle player movement
	private void Move()
    {
        // Determine whether player is pressing W/A/S/D
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

		
		if (moveVertical > 0f || moveVertical < 0f || moveHorizontal > 0f || moveHorizontal < 0f)
        {
            float newMoveSpeed = moveSpeed * Time.deltaTime; // Smooth player movement
            // Move player using transform
            transform.Translate(moveHorizontal * newMoveSpeed, 0f, moveVertical * newMoveSpeed);
            
            // Clamp the player's position so they can't go out of bounds.
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, xMin, xMax);
            clampedPosition.z = Mathf.Clamp(clampedPosition.z, zMin, zMax);
            transform.position = clampedPosition;
        }
		else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W))
		{
			transform.Translate(0 * 0, 0f, 0 * 0);
		}
	}

    // Handle player's ability to flip
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Spike")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public float linearDrag;
    private void OnTriggerEnter(Collider other)
    {
        // Handle gravity with Quicksand when player enters it
        if(other.gameObject.tag == "Spike")
        {
            playerRB.drag = linearDrag;
        }
    }
}
