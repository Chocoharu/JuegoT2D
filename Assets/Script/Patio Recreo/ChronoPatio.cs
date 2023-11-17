using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChronoPatio : MonoBehaviour
{
    public TextMeshProUGUI Texttiempo;
    public float tiempo = 0f;

    public GameObject Pause;
    //[SerializeField] private bool dialog = true; // si existe algun dialogo activarlo

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        
        if (tiempo >= 10f)
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
