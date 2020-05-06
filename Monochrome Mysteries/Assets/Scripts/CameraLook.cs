/************************************************************************************************
// File Name:   CameraLook.cs
// Author:      Jamey Colleen
// Description: This script is made to properly control the direction the camera is always pointing
//              in accordance with the player's transform.
************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
	float lookVertical;
	float lookHorizontal;
	public float verticalClamp;
	GameObject player;

	// Start is called before the first frame update
	void Start()
    {
		player = GameObject.Find("Player");

	}

	// Update is called once per frame
	void Update()
    {
		lookHorizontal += Input.GetAxis("Mouse X");
		lookVertical = Mathf.Min(verticalClamp, Mathf.Max(-verticalClamp, lookVertical + -Input.GetAxis("Mouse Y")));
		player.transform.localRotation = Quaternion.Euler(0, lookHorizontal, 0);
		transform.localRotation = Quaternion.Euler(lookVertical, 0, 0);
	}
}
