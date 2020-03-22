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

    public void PreviousPage()
    {
        pageValue --;

        if (pageValue < 1)
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
}
