using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeObjetos : MonoBehaviour
{
    public GameObject objetoPrefab;
    public GameObject objetoPrefab1;
    public GameObject objetoPrefab2;
    private Transform t;
    public float intervaloDeGeneracion = 1.0f;
    public float rangoYMinimo;
    public float rangoYMaximo;
    public bool dir;

    private void Start()
    {
        // Comienza a generar objetos en intervalos regulares.
        InvokeRepeating("GenerarObjeto", 0, intervaloDeGeneracion);
    }

    private void GenerarObjeto()
    {
        float randomValue = Random.value;

        GameObject objetoGenerado;

        // 40% de probabilidad de generar objetoPrefab
        if (randomValue <= 0.4f)
        {
            objetoGenerado = Instantiate(objetoPrefab, ObtenerPosicionAleatoria(), Quaternion.identity);

        }
        // 30% de probabilidad de generar objetoPrefab1
        else if (randomValue <= 0.7f)
        {
            objetoGenerado = Instantiate(objetoPrefab1, ObtenerPosicionAleatoria(), Quaternion.identity);
        }
        // 30% de probabilidad de generar objetoPrefab2
        /*else
        {
            objetoGenerado = Instantiate(objetoPrefab2, ObtenerPosicionAleatoria(), Quaternion.identity);
            objetoGenerado.transform.Translate(Vector2.right * 5 * Time.deltaTime);
        }*/
    }
    private Vector3 ObtenerPosicionAleatoria()
    {
        float posY = Random.Range(rangoYMinimo, rangoYMaximo);
        return new Vector3(transform.position.x, posY, transform.position.z);
    }
    public bool DireccionAlumno()
    {
        return dir;
    }
}
