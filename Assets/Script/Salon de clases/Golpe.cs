using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Golpe : MonoBehaviour
{
    public Transform[] objetivos;
    public float distanciaMinima;
    public TextMeshProUGUI Scoretxt;
    public int puntaje = 0;
    public LayerMask EstudiantesLayer;    
    public bool permiso;
    private Animator animator;

    public bool exito = false;
    public int cantAlert = 0;
    public float tempo = 0f;
    public float ContadorRegresivo = 6f;
    public bool nextscene = false;
    [SerializeField] private BarraDeVida barraDeVida;
    public int NumeroEstudiantesAlarm = 3;

    public TextMeshProUGUI cuentaRegresiva;
    public GameObject objCuentaRegresiva;
    public int sliderline=4;

    public AudioClip sonido; // Asigna tu clip de audio desde el Editor de Unity
    public AudioSource audioSource;

    private float TimerGolpe = 1f;
    private bool PermisoGolpe;
    

    // Start is called before the first frame update
    void Start()
    {
        objetivos = GameObject.FindGameObjectsWithTag("Estudiante").Select(obj => obj.transform).ToArray();
        if (SceneManager.GetActiveScene().name == "Juego")
        {
            
            //barraDeVida.InicializarBarraDeVida(4);
            barraDeVida.InicializarBarraDeVida(sliderline);
        }
        //objetivos = GameObject.FindGameObjectsWithTag("Estudiante").Select(obj => obj.transform).ToArray();
        animator = GetComponent<Animator>();
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Juego" || SceneManager.GetActiveScene().name == "juego2")
        {


            if (Input.GetKeyDown(KeyCode.Space))
            {
                PermisoGolpe = true;
                animator.SetBool("Golpear", PermisoGolpe);
                foreach (Transform estudiante in objetivos)
                {
                    float distancia = Vector2.Distance(transform.position, estudiante.position);

                    if (distancia < distanciaMinima && estudiante.GetComponent<Alerta>().permisoGolpe)
                    {
                        //animator.SetBool("Golpear", true);

                        audioSource.clip = sonido;
                        audioSource.Play();

                        estudiante.GetComponent<Alerta>().Destruir();
                        //exito = true;
                        puntaje += 100;
                        cantAlert--;
                        barraDeVida.CambiarVidaActual(cantAlert);
                        Scoretxt.text = "Puntaje: " + puntaje;
                        PlayerPrefs.SetInt("Puntaje", puntaje);
                        PlayerPrefs.Save();
                        exito = true;
                    }
                }
            }
            if (cantAlert >= NumeroEstudiantesAlarm)
            {
                tempo += Time.deltaTime;
                objCuentaRegresiva.SetActive(true);
                ContadorRegresivo -= Time.deltaTime;
                Cronometro();

                if (tempo >= 5f && !nextscene) //muerte?
                {

                    string nombreEscenaActual = SceneManager.GetActiveScene().name;
                    // Almacenar el nombre de la escena actual como la "EscenaAnterior"
                    PlayerPrefs.SetString("EscenaAnterior", nombreEscenaActual);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("FinalMalo");

                    nextscene = true;
                }
            }
            else
            {
                tempo = 0f;
                ContadorRegresivo = 6;
                objCuentaRegresiva.SetActive(false);
                nextscene = false;
            }
        }
        if(SceneManager.GetActiveScene().name == "Biblioteca" || SceneManager.GetActiveScene().name == "Biblioteca2")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                PermisoGolpe = true;
                animator.SetBool("Golpear", PermisoGolpe);
                foreach (Transform estudiante in objetivos)
                {
                    float distancia = Vector2.Distance(transform.position, estudiante.position);

                    // Verifica si la distancia es menor que la distancia m�nima
                    if (distancia < distanciaMinima)
                    {
                        estudiante.GetComponent<OcultarEstudiante>().ReturnToOriginalPosition();
                    }
                }
            }
        }
        if(PermisoGolpe)
        {
            TimerGolpe -= Time.deltaTime;
            if(TimerGolpe<=0)
            {
                PermisoGolpe = false;
                animator.SetBool("Golpear", PermisoGolpe);
                TimerGolpe = 1;
            }
        }
    }
    public void CantAlertas()
    {
        cantAlert++;
        barraDeVida.CambiarVidaActual(cantAlert);
    }
    void Cronometro()
    {
        //int minutos = Mathf.FloorToInt(tempo / 60);
        int segundos = Mathf.FloorToInt(ContadorRegresivo % 60);
        //int milisegundos = Mathf.FloorToInt((tempo * 1000) % 1000);

        string tiempoTexto = string.Format("{0:00}",segundos);
        cuentaRegresiva.text = tiempoTexto;

        //PlayerPrefs.SetFloat("TotalTiempo", tempo);

    }
}
