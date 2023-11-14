using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAve : MonoBehaviour
{
    public float velocidad;
    private bool PosGeneracion;
    public Rigidbody2D rg;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        PosGeneracion = transform.position.x < 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PosGeneracion) { transform.Translate(Vector2.right * velocidad * Time.deltaTime); }
        else { transform.Translate(Vector2.left * velocidad * Time.deltaTime); }
    }
}
