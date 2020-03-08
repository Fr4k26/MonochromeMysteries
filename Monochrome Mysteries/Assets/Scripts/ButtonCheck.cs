using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCheck : MonoBehaviour
{
    DialgoueManager manager;
    Button endButton;

    void Start()
    {
        manager = FindObjectOfType<DialgoueManager>();
    }

    public void EndConvo()
    {
        manager.gameObject.SetActive(false);
    }
}
