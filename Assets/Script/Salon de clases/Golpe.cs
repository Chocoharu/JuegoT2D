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
    public bool nextscene = false;
    [SerializeField] private BarraDeVida barraDeVida;

    // Start is called before the first frame update
    void Start()
    {
        objetivos = GameObject.FindGameObjectsWithTag("Estudiante").Select(obj => obj.transform).ToArray();
        animator = GetComponent<Animator>();
        barraDeVida.InicializarBarraDeVida(4);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            foreach (Transform estudiante in objetivos)
            {
                float distancia = Vector2.Distance(transform.position, estudiante.position);

                if (distancia < distanciaMinima && estudiante.GetComponent<Alerta>().permisoGolpe)
                {
                    exito = true;
                    //animator.SetBool("Golpear", exito);
                } 
            }
        }
        //bool Permiso = alerta.PermisoGolpe();
        if (Input.GetKeyUp(KeyCode.E))
        {
            foreach (Transform estudiante in objetivos)
            {
                float distancia = Vector2.Distance(transform.position, estudiante.position);

                // Verifica si la distancia es menor que la distancia mínima
                if (distancia < distanciaMinima )
                {
                    if (estudiante.GetComponent<Alerta>().permisoGolpe)
                    {
                        //animator.SetBool("Golpear", true);
                        estudiante.GetComponent<Alerta>().Destruir();
                        //exito = true;
                        puntaje += 100;
                        cantAlert--;
                        barraDeVida.CambiarVidaActual(cantAlert);
                        Scoretxt.text = "Puntaje: " + puntaje;
                        PlayerPrefs.SetInt("Puntaje", puntaje);
                        PlayerPrefs.Save();
                    }    
                }
                exito = false;
                //animator.SetBool("Golpear", exito);
            }
        }
        if (cantAlert >= 3)
        {
            tempo += Time.deltaTime;
            if(tempo >= 5f && !nextscene)
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                
                nextscene = true;
            }
        }
        else
        {
            tempo = 0f;
            nextscene = false;
        }
    }
    public void CantAlertas()
    {
        cantAlert++;
        barraDeVida.CambiarVidaActual(cantAlert);
    }
}
