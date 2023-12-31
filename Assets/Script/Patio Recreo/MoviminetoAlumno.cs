using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviminetoAlumno : MonoBehaviour
{
    public float velocidad = 2.0f;
    private bool PosGeneracion;
    public bool PermisoMovimiento;
    private float Timer = 1f;
    public GameObject pause;
    public bool isAve = false;
    //public bool Ej = false;
    // Start is called before the first frame update
    void Start()
    {
        PosGeneracion = transform.position.x < 0;
        PermisoMovimiento = true;
        velocidad += Random.Range(0f, 2f);
        if (PosGeneracion)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pause != null)
        {
            if (pause.activeSelf)
            {
                return;
            }
        }
        if (PermisoMovimiento || isAve)
        {
            if (PosGeneracion) { transform.Translate(Vector2.right * velocidad * Time.deltaTime); }
            else { transform.Translate(Vector2.left * velocidad * Time.deltaTime); }
        }
        else
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                PermisoMovimiento = true;
            }
        }
    }
}
