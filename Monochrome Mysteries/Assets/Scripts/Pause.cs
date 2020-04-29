/************************************************************************************************
// File Name:   Pause.cs
// Author:      Jake Hyland
// Description: Contains a the Pause and Continue functions necessary to bring up or hide the pause menu as well as disable
                other player actions when said menu is displayed.
************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject pausePanel;
    private bool paused = false;
    private GameObject cameraObject;
    public GameObject journalUI;
    public GameObject howUI;
    public GameObject optionsUI;

    private PlayerController playerController;

    void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        pausePanel = GameObject.Find("Pause Panel");
        pausePanel.SetActive(false);
        cameraObject = GameObject.Find("Main Camera");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused && playerController.canmove == true)
            {
                PauseGame();
            }
            if (paused)
            {
                ContinueGame();
            }
        }
    }
    private void PauseGame()
    {
        Cursor.visible = true;
        cameraObject.GetComponent<CameraController>().enabled = false;
        journalUI.SetActive(false);
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        StartCoroutine("pauseWait");
        Cursor.lockState = CursorLockMode.None;
        //Disable scripts that still work while timescale is set to 0
    }
    public void ContinueGame()
    {
        playerController.canmove = true;
        cameraObject.GetComponent<CameraController>().enabled = true;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        optionsUI.SetActive(false);
        howUI.SetActive(false);
        StartCoroutine("pauseWait");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //enable the scripts again and the ability to move
    }
     private IEnumerator pauseWait()
    {
        yield return new WaitForSeconds(0.0f);
        paused = !paused;
    }
}
