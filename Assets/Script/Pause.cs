using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    public GameObject PauseObj;
    public GameObject panelPause;
    public GameObject BtnPause;
    
    Transiciones transiciones;

    float currentTime = 0;
    
    private void Start()
    {
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
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
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    public void SpecialPause()
    {
        //Debug.Log("clic");
        panelPause.SetActive(true);
        Time.timeScale = 0f;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Pause();
        }

    }
    public void Run()
    {
        Time.timeScale = 1.0f;
        panelPause.SetActive(false);

        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Play();
        }
    }

}
