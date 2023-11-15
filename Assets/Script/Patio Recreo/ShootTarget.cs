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
    private float Timer = 3f;
    private Renderer renderer;
    public bool newBorn = false;
    public float StartInquieto;
    public bool Movimiento = true;
    private static int ContTierra = 0;

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

            if (randomValue <= 0.2f&&!cambioColor&&!CompareTag("Ave"))
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
                if (!click && CompareTag("Estudiante")&& ContTierra < 3)
                {
                    Instantiate(Tierra, new Vector3(0, 0, 0), Quaternion.identity);
                    ContTierra++;
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
            
            //renderer.material.color = Color.white;
            //Destroy(gameObject);
        }
        else if((CompareTag("Estudiante") && !Inquieto))
        {
            PlaygroundShoot.Instance.RemovePoint(100);
            this.gameObject.GetComponent<MoviminetoAlumno>().PermisoMovimiento = false;
            click = true;
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
