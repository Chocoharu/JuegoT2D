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
    [SerializeField] private bool dialog = true; // si existe algun dialogo activarlo

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialog == true)
        {
            if (Pause.activeSelf)
            {
                return;
            }
        }
        if (tiempo >= 30f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        tiempo += Time.deltaTime;
        Cronometro();
    }
    void Cronometro()
    {
        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);
        int milisegundos = Mathf.FloorToInt((tiempo * 1000) % 1000);

        string tiempoTexto = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, milisegundos);
        Texttiempo.text = tiempoTexto;

        PlayerPrefs.SetFloat("TotalTiempo", tiempo);

    }

}
