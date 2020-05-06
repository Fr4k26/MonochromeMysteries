/************************************************************************************************
// File Name:   PlayerController.cs
// Authors:     Jamey Colleen (40%), David Suriano (45%), and Jake Hyland (15%)
// Description: Contains the functions allowing the Player to control their avatar and limits
//              them from moving under certain conditions. Originally written by Jamey, with
//              significant updates for movement from David, and sound-specific code from Jake.
************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	PlayerController playerController;
    Rigidbody playerRB;
    GameObject camera;

    public bool canClimb = false;
    public float walkSpeed;
	public float sprintSpeed;
	private float moveSpeed;
	float distToGround = 2f;
    float lastYPos;
    public bool canmove = true;

    public AudioClip[] walkingSounds;
    public AudioClip[] runningSounds;
    private AudioSource stepSource;
    private bool isSprinting = false;
    private bool isMoving = true;


    // Min and max values for player position -- use for boundaries regarding where you want the player to go.
    public float xMin, xMax, zMin, zMax;

    // Assign private variable
    private void Start()
	{
        canClimb = false;
		moveSpeed = walkSpeed;
        //stateSwap = FindObjectOfType<StateSwap>();
        playerRB = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
		playerController = GetComponent<PlayerController>();
        lastYPos = GetComponent<Rigidbody>().transform.position.y;
        camera = FindObjectOfType<CameraCollision>().gameObject;
        stepSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    // Handle frame-based events


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canmove)
        {
            moveSpeed = sprintSpeed;
            isSprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && canmove)
        {
            moveSpeed = walkSpeed;
            isSprinting = false;
        }

       

        //Vertical limits
        if (isGrounded())
        {
            lastYPos = transform.position.y;
        }
        else if (transform.position.y >= lastYPos + 3)
        {
            playerRB.velocity = new Vector3(playerRB.velocity.x, playerRB.velocity.y / 1.75f, playerRB.velocity.z);
        }
        
    }

    void FixedUpdate()
    {
        Move();
    }
    bool isGrounded()
	{
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}
	// Handle player movement
	private void Move()
    {
        if (canmove)
        {
            // Determine whether player is pressing W/A/S/D
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");


            if ((moveVertical > 0f || moveVertical < 0f || moveHorizontal > 0f || moveHorizontal < 0f) && canmove)
            {
                float newMoveSpeed = moveSpeed * Time.deltaTime; // Smooth player movement
                                                                 // Move player using transform
                                                                 //transform.Translate(moveHorizontal * newMoveSpeed, 0f, moveVertical * newMoveSpeed);
                                                                 //Vector3 nextMove = (playerRB.position + Vector3.ClampMagnitude(camera.transform.rotation * new Vector3(moveHorizontal, 0f, moveVertical), newMoveSpeed));
                                                                 //playerRB.MovePosition(nextMove);

                StartCoroutine(nextStep());
                Vector3 moveDir = new Vector3(moveHorizontal * newMoveSpeed, 0f, moveVertical * newMoveSpeed);
                Vector3 feet = transform.position + new Vector3(0, -.75f, 0);
                if(!Physics.Raycast(feet, transform.TransformDirection(moveDir), .5f))//If you aren't going to run into something
                {
                    //transform.Translate(moveDir);
                    //playerRB.MovePosition(transform.position);
                    playerRB.MovePosition(transform.position + transform.TransformDirection(moveDir));
                    
                }
            }
        }
	}

    IEnumerator nextStep()
    {
        if (isSprinting && isMoving == true)
        {
            stepSource.PlayOneShot(runningSounds[Random.Range(0, runningSounds.Length)], 0.25f);
            isMoving = false;
            yield return new WaitForSeconds(0.255f);
            isMoving = true;
        }
        if (isSprinting == false && isMoving == true)
        {
            stepSource.PlayOneShot(walkingSounds[Random.Range(0, walkingSounds.Length)], 0.2f);
            isMoving = false;
            yield return new WaitForSeconds(0.425f);
            isMoving = true;
        }
    }

        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canClimb = false;
            canmove = true;
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Beta Level");
    }

    public void MainScene()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public float linearDrag;
}
