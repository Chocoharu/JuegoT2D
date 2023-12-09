using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TiempoTotal : MonoBehaviour
{

    public TextMeshProUGUI TotalTiempo;
    public TextMeshProUGUI PuntajeTexto;
    public TextMeshProUGUI AprendizajeTotal;

    // Start is called before the first frame update
    void Start()
    {
        float tiempo = PlayerPrefs.GetFloat("TotalTiempo", 0f);
        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);
        int milisegundos = Mathf.FloorToInt((tiempo * 1000) % 1000);

        string tiempoTexto = string.Format("Has aguantado: {0:00}:{1:00}:{2:000}", minutos, segundos, milisegundos);
        TotalTiempo.text = tiempoTexto;
        int puntaje = PlayerPrefs.GetInt("Puntaje", 0);
        PuntajeTexto.text = "Puntaje: " + puntaje;
        string escenaAnterior = PlayerPrefs.GetString("EscenaAnterior", "Inicio");
        if (escenaAnterior == "Biblioteca" || escenaAnterior == "Biblioteca2")
        {
            int aprendizaje = PlayerPrefs.GetInt("Aprendizaje", 0);
            AprendizajeTotal.text = "Aprendizaje: " + aprendizaje;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
