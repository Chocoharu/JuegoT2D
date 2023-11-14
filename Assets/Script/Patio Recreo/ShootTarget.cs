using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ShootTarget : MonoBehaviour
{
    private bool Inquieto = false;
    private float Timer = 3f;
    private Renderer renderer;
    public bool newBorn = false;
    public float StartInquieto;
    public bool Movimiento = true;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        StartInquieto = Random.Range(3f, 5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(newBorn)
        {
            float randomValue = Random.value;

            if (randomValue <= 0.2f)
            {
                Inquieto = true;
                renderer.material.color = Color.red;
            }
            /*Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                Inquieto = false;
                renderer.material.color = Color.white;
            }*/
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
        if (CompareTag("Estudiante") && Inquieto)
        {
            PlaygroundShoot.Instance.AddPoint(100);
            this.gameObject.GetComponent<MoviminetoAlumno>().PermisoMovimiento = false;
            /*Inquieto = false;
            renderer.material.color = Color.white;*/
            //Destroy(gameObject);
        }
        else if((CompareTag("Estudiante") && !Inquieto))
        {
            PlaygroundShoot.Instance.RemovePoint(100);
            this.gameObject.GetComponent<MoviminetoAlumno>().PermisoMovimiento = false;
            //Destroy(gameObject);
        }
        else if (CompareTag("Ave"))
        {
            PlaygroundShoot.Instance.RemovePoint(100);
            this.gameObject.GetComponent<MovimientoAve>().rg.gravityScale = 3;
            //Destroy(gameObject);
        }
    }

    public bool PermisoMovimiento()
    {
        return Movimiento;
    }
}
