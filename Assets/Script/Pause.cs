using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    public GameObject PauseObj;
    public GameObject panelPause;
    public GameObject BtnPause;

    public void initPause()
    {
        PauseObj.SetActive(true);
        panelPause.SetActive(true);
    }
    public void EndPause()
    {
        PauseObj.SetActive(false);
        panelPause.SetActive(false);
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
    }
}
