using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuPause : MonoBehaviour
{
    public GameObject Panel_Menu;
    public GameObject Panel_Options;
    public GameObject Panel_Ctrl;

    public void PanelMenu()
    {
        if (Panel_Options.activeSelf)
        {
            Panel_Options.SetActive(false);
            Panel_Menu.SetActive(true);
        }
        else
        {
            Panel_Ctrl.SetActive(false);
            Panel_Menu.SetActive(true);
        }    
    }
    public void PanelCtrl()
    {
        Panel_Ctrl.SetActive(true);
        Panel_Menu.SetActive(false);
    }
    public void PanelOptions()
    {
        Panel_Options.SetActive(true);
        Panel_Menu.SetActive(false);
    }

}
