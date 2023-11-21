using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeObjetos : MonoBehaviour
{
    public GameObject objetoPrefab;
    public GameObject objetoPrefab1;
    public float intervaloDeGeneracion = 3.0f;
    public float rangoYMinimo;
    public float rangoYMaximo;
    public GameObject Pause;

    private void Start()
    {
       
        // Comienza a generar objetos en intervalos regulares.
        InvokeRepeating("GenerarObjeto", 0, intervaloDeGeneracion);
    }

    private void GenerarObjeto()
    {
        if (Pause != null)
        {
            if (Pause.activeSelf)
            {
                return;
            }
        }
        float randomValue = Random.value;

        GameObject objetoGenerado;

        // 70% de probabilidad de generar objetoPrefab
        if (randomValue <= 0.7f)
        {
            objetoGenerado = Instantiate(objetoPrefab, ObtenerPosicionAleatoria(), Quaternion.identity);

        }
        // 30% de probabilidad de generar objetoPrefab1
        else if (randomValue <= 1f)
        {
            objetoGenerado = Instantiate(objetoPrefab1, ObtenerPosicionAleatoria(), Quaternion.identity);
        }
    }
    private Vector3 ObtenerPosicionAleatoria()
    {
        float posY = Random.Range(rangoYMinimo, rangoYMaximo);
        return new Vector3(transform.position.x, posY, transform.position.z);
    }
}
