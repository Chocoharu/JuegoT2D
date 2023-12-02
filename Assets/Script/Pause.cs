using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    public GameObject PauseObj;
    public GameObject panelPause;
    public GameObject BtnPause;
    

    float currentTime = 0;
    
    private void Start()
    {
        currentTime += Time.deltaTime;
    }
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
    public void SpecialPause()
    {
        Debug.Log("clic");
        panelPause.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Run()
    {
        Time.timeScale = 1.0f;
        panelPause.SetActive(false);
    }

}
