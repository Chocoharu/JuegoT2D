using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ShootTarget : MonoBehaviour
{
    public GameObject Tierra;
    private bool Inquieto = false;
    private bool cambioColor = false;
    private bool click = false;
    private float Timer = 2f;
    private new Renderer renderer;
    public bool newBorn = false;
    public float StartInquieto;
    public bool Movimiento = true;
    public MedidorDirector barraDirector;
    private bool permitirGenerarTierra = true;
    private float tiempoEsperaGeneracion = 2.0f;
    //private float tiempoEsperaDisminucion = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        barraDirector = MedidorDirector.instance;
        renderer = GetComponent<Renderer>();
        StartInquieto = Random.Range(2f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        if(barraDirector == null)
        {
            barraDirector = MedidorDirector.instance;
        }

        if(newBorn)
        {
            float randomValue = Random.value;

            if (randomValue <= 0.5f&&!cambioColor&&!CompareTag("Ave")&& !CompareTag("AveEjemplo"))
            {
                Inquieto = true;
                renderer.material.color = Color.red;
                cambioColor = true;
            }
            Timer -= Time.deltaTime;
            if (Timer <= 0 || click)
            {
                Inquieto = false;
                renderer.material.color = Color.white;
                if (!click && permitirGenerarTierra)
                {
                    permitirGenerarTierra = false;
                    StartCoroutine(ReiniciarGeneracionTierra());

                    Instantiate(Tierra, new Vector3(0, -2, 0), Quaternion.identity);
                    Tierra.GetComponent<SpriteRenderer>().sortingOrder = 1;

                    barraDirector.CambiarVidaActual(1);
                    PlaygroundShoot.Instance.RemovePoint(20);
                }
                
            }
        }
        else
        {
            StartInquieto-= Time.deltaTime;
            if(StartInquieto <= 0)
            {
                newBorn = true;
            }
        }
    }

    private void OnMouseDown()
    {
        if (click) return;
        if (CompareTag("Estudiante") && Inquieto)
        {
            PlaygroundShoot.Instance.AddPoint(100);
            this.gameObject.GetComponent<MoviminetoAlumno>().PermisoMovimiento = false;
            click = true;
            
            renderer.material.color = Color.white;
        }
        else if((CompareTag("Estudiante") && !Inquieto))
        {
            PlaygroundShoot.Instance.RemovePoint(50);
            barraDirector.CambiarVidaActual(1);
            this.gameObject.GetComponent<MoviminetoAlumno>().PermisoMovimiento = false;
            click = true;
        }
        else if (CompareTag("Ave") || CompareTag("AveEjemplo"))
        {
            PlaygroundShoot.Instance.RemovePoint(25);
            barraDirector.CambiarVidaActual(1);
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
        }
    }
    IEnumerator ReiniciarGeneracionTierra()
    {
        yield return new WaitForSeconds(tiempoEsperaGeneracion);
        permitirGenerarTierra = true;
    }
}
