using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    public Canvas boyCanvas;
    public bool boyTrigger;
    public Canvas femmeCanvas;
    public bool femmeTrigger;
    public Canvas mobCanvas;
    public bool mobTrigger;
    //public Canvas manCanvas;
    //public bool manTrigger;
    public GameObject triggerObj;
    public GameObject cameraUser;

    // Update is called once per frame
    public void OnTriggerEnter(Collider collider)
    {
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

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        cameraUser.GetComponent<CameraLook>().enabled = false;
    }

    public void OnTriggerExit(Collider other)
    {
        boyCanvas.gameObject.SetActive(false);
        boyTrigger = false;
        femmeCanvas.gameObject.SetActive(false);
        femmeTrigger = false;
        mobCanvas.gameObject.SetActive(false);
        mobTrigger = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cameraUser.GetComponent<CameraLook>().enabled = true;
    }
}
