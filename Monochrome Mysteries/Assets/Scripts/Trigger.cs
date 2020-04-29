using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public Canvas boyCanvas;
    public bool boyTrigger;
    public Canvas femmeCanvas;
    public bool femmeTrigger;
    public Canvas mobCanvas;
    public bool mobTrigger;
    public Canvas manCanvas;
    public bool manTrigger;
    public UnityEvent makeItActive;
    private GameObject playerObject;

    public GameObject triggerObj;
    public GameObject cameraUser;

    void Start()
    {
        playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider collider)
    {
        makeItActive.Invoke();
        if(triggerObj.CompareTag("Paper Boy"))
        {
            boyCanvas.gameObject.SetActive(true);
            boyTrigger = true;
        }
        if (triggerObj.CompareTag("Femme Fatale"))
        {
            femmeCanvas.gameObject.SetActive(true);
            femmeTrigger = true;
        }
        if (triggerObj.CompareTag("Mob Boss"))
        {
            mobCanvas.gameObject.SetActive(true);
            mobTrigger = true;
        }
        if (triggerObj.CompareTag("Businessman"))
        {
            manCanvas.gameObject.SetActive(true);
            manTrigger = true;
        }

        playerObject.GetComponent<Pause>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        cameraUser.GetComponent<CameraLook>().enabled = false;
    }

    public void OnTriggerExit(Collider other)
    {
        playerObject.GetComponent<Pause>().enabled = true;
        boyCanvas.gameObject.SetActive(false);
        boyTrigger = false;
        femmeCanvas.gameObject.SetActive(false);
        femmeTrigger = false;
        mobCanvas.gameObject.SetActive(false);
        mobTrigger = false;
        manCanvas.gameObject.SetActive(false);
        manTrigger = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cameraUser.GetComponent<CameraLook>().enabled = true;
    }
}
