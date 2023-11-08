using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeObjetos : MonoBehaviour
{
    public GameObject objetoPrefab; // El GameObject que quieres generar.
    public float intervaloDeGeneracion = 1.0f; // El intervalo entre generaciones.
    public float rangoYMinimo = -2.0f; // Valor mínimo en el eje Y.
    public float rangoYMaximo = 2.0f; // Valor máximo en el eje Y.
    public bool dir;

    private void Start()
    {
        // Comienza a generar objetos en intervalos regulares.
        InvokeRepeating("GenerarObjeto", 0, intervaloDeGeneracion);
    }

    private void GenerarObjeto()
    {
        // Genera un objeto en una posición aleatoria en el eje Y.
        float posY = Random.Range(rangoYMinimo, rangoYMaximo);
        Vector3 posicionGeneracion = new Vector3(transform.position.x, posY, transform.position.z);
        Instantiate(objetoPrefab, posicionGeneracion, Quaternion.identity);
    }

    public bool DireccionAlumno()
    {
        return dir;
    }
}
