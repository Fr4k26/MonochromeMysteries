/************************************************************************************************
// File Name:   PageCheck.cs
// Author:      Jake Hyland
// Description: Contains the two functions called by buttons on the How To Play Screen in
//              order to properly display new pages, as well as loop back from the last page
//              to the first one and vice versa.
************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageCheck : MonoBehaviour
{

    public int pageValue;
    public int displayValue;
    public GameObject pagePanel;

    // Start is called before the first frame update
    void Awake()
    {
        //pagePanel = this.gameObject;
    }

    public void NextPage()
    {
        pageValue ++;

        if (pageValue > 4)
        {
            pageValue = 1;
        }

        if (pageValue == displayValue)
        {
            pagePanel.SetActive(true);
        }
        else if (pageValue != displayValue)
        {
            pagePanel.SetActive(false);
        }
    }

    public void PreviousPage()
    {
        pageValue --;

        if (pageValue < 1)
        {
            pageValue = 4;
        }

        if (pageValue == displayValue)
        {
            pagePanel.SetActive(true);
        }
        else if (pageValue != displayValue)
        {
            pagePanel.SetActive(false);
        }
    }
}
