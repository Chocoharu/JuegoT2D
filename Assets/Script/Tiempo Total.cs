using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TiempoTotal : MonoBehaviour
{

    public TextMeshProUGUI TotalTiempo;
    public TextMeshProUGUI PuntajeTexto;

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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
