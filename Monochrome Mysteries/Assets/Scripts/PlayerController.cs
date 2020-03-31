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
	public float jumpSpeed;
    float lastYPos;
    public bool canmove = true;
    

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
    }

    // Handle frame-based events


    private void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() && canmove)
        {
            playerRB.velocity = new Vector3(0f, jumpSpeed, 0f);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canmove)
        {
            moveSpeed = sprintSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && canmove)
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
            playerRB.velocity = new Vector3(playerRB.velocity.x, playerRB.velocity.y / 1.75f, playerRB.velocity.z);
        }
        
        //Restart Scene
        //if (Input.GetKeyDown(KeyCode.F11))
        //    SceneManager.LoadScene("Verticle Slice");
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

                transform.Translate(moveHorizontal * newMoveSpeed, 0f, moveVertical * newMoveSpeed);
                playerRB.MovePosition(transform.position);
            }
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

    public float linearDrag;
}
