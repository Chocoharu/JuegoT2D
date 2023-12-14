using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Chrono : MonoBehaviour
{
    public TextMeshProUGUI Texttiempo;
    private float tiempo = 30f;

    public GameObject Pause;
    public Canvas Transicion;
    //public GameObject areaEstudio;

    //private Animator animator;
    //[SerializeField] private AnimationClip animacionFinal;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
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
        tiempo -= Time.deltaTime;
        Cronometro();

        if (tiempo <= 0f )
        {
            Transicion.GetComponent<Transiciones>().StartCoroutine("CambiarEscena");

        }
        
    }
    void Cronometro()
    {
        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);
        string tiempoTexto;

        if (tiempo <= 0f)
        {
            tiempoTexto = string.Format("{0:00}:{1:00}", 0, 0);
        }
        else
        {
            tiempoTexto = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
        Texttiempo.text = tiempoTexto;
        PlayerPrefs.SetFloat("TotalTiempo", tiempo);
    }
}
