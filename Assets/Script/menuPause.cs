using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuPause : MonoBehaviour
{
    public GameObject Panel_Menu;
    public GameObject Panel_Options;

    public void PanelMenu()
    {
        Panel_Options.SetActive(false);
        Panel_Menu.SetActive(true);
    }
    public void PanelOptions()
    {
        Panel_Options.SetActive(true);
        Panel_Menu.SetActive(false);
    }

}
