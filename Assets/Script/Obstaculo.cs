using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    private Renderer render;
    private Collider2D col;
    private float minTiempoVisible = 1.0f;
    private float maxTiempoVisible = 3.0f;

    private float minTiempoInvisible = 1.0f;
    private float maxTiempoInvisible = 3.0f;

    public GameObject Pause;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        col.enabled = false;
        render = GetComponent<Renderer>();
        render.enabled = false;
        StartCoroutine(GeneradorObstaculos());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator GeneradorObstaculos()
    {
        while (true) // Esto generará sprites indefinidamente
        {
            float tiempoVisible = Random.Range(minTiempoVisible, maxTiempoVisible);
            yield return new WaitForSeconds(tiempoVisible);
            col.enabled = false;
            render.enabled = false;

            //Eligo tiempo de espera al azar y espero ese tiempo
            //tiempoGeneracion = Random.Range(2.0f, 3.0f);
            float tiempoInvisible = Random.Range(minTiempoInvisible, maxTiempoInvisible);
            yield return new WaitForSeconds(tiempoInvisible);
            col.enabled = true;
            render.enabled = true;
        }
    }


}
