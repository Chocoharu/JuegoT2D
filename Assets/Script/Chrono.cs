using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Chrono : MonoBehaviour
{
    public TextMeshProUGUI Texttiempo;
    public float tiempo = 0f;

    public GameObject Pause;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause != null)
        {
            if (Pause.activeSelf)
            {
                return;
            }
        }
        tiempo += Time.deltaTime;

        if (tiempo >= 60f && SceneManager.GetActiveScene().name == "Juego")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }
        if (tiempo >= 30f && SceneManager.GetActiveScene().name == "Patio")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        Cronometro();
    }
    void Cronometro()
    {
        Debug.Log("Cronometro() llamado en escena: " + SceneManager.GetActiveScene().name);
        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);
        int milisegundos = Mathf.FloorToInt((tiempo * 1000) % 1000);

        string tiempoTexto = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, milisegundos);
        Texttiempo.text = tiempoTexto;

        PlayerPrefs.SetFloat("TotalTiempo", tiempo);

    }

}
