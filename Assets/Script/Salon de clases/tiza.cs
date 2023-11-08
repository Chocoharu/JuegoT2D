using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiza : MonoBehaviour
{
    public Golpe golpe; // Agrega una referencia al script Golpe
    public BarraDeVida barraDeVida; // Agrega una referencia a la barra de vida

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Estudiante"))
        {
            Alerta alerta = collision.gameObject.GetComponent<Alerta>();
            if (alerta != null && alerta.PermisoGolpe())
            {
                alerta.Destruir(); // Destruye el estudiante
                golpe.puntaje += 100;
                golpe.cantAlert--;
                barraDeVida.CambiarVidaActual(golpe.cantAlert);
                golpe.Scoretxt.text = "Puntaje: " + golpe.puntaje;
            }
            Destroy(this.gameObject); // Destruye la tiza
        }
    }
}
