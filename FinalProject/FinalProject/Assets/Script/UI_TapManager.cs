using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TapManager : MonoBehaviour
{
    public GameObject tab_set;
    public GameObject tab_setImg_On;
    public GameObject tab_setImg_Off;
    public bool tabOn1;

    public GameObject tab_how;
    public GameObject tab_howImg_On;
    public GameObject tab_howImg_Off;
    public bool tabOn2;

    public GameObject tab_info;
    public GameObject tab_infoImg_On;
    public GameObject tab_infoImg_Off;
    public bool tabOn3;

    void start()
    {
        tabOn1 = true;
        tabOn2 = false;
        tabOn3 = false;
        tab_set_event();
    }

    public void tab_set_event()
    {
        tab_set.SetActive(true);
        tab_how.SetActive(false);
        tab_info.SetActive(false);

        tabOn1 = true;
        tabOn2 = false;
        tabOn3 = false;

        tabImg_toggle();
    }

    public void tab_how_event()
    {
        tab_set.SetActive(false);
        tab_how.SetActive(true);
        tab_info.SetActive(false);

        tabOn1 = false;
        tabOn2 = true;
        tabOn3 = false;

        tabImg_toggle();
    }

    public void tab_info_event()
    {
        tab_set.SetActive(false);
        tab_how.SetActive(false);
        tab_info.SetActive(true);

        tabOn1 = false;
        tabOn2 = false;
        tabOn3 = true;

        tabImg_toggle();
    }

    void tabImg_toggle()
    {
        if(tabOn1)
        {
            tab_setImg_On.SetActive(true);
            tab_setImg_Off.SetActive(false);
        }
        else
        {
            tab_setImg_On.SetActive(false);
            tab_setImg_Off.SetActive(true);
        }

        if(tabOn2)
        {
            tab_howImg_On.SetActive(true);
            tab_howImg_Off.SetActive(false);
        }
        else
        {
            tab_howImg_On.SetActive(false);
            tab_howImg_Off.SetActive(true);
        }

        if(tabOn3)
        {
            tab_infoImg_On.SetActive(true);
            tab_infoImg_Off.SetActive(false);
        }
        else
        {
            tab_infoImg_On.SetActive(false);
            tab_infoImg_Off.SetActive(true);
        }
    }
}
