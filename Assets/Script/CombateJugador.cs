using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombateJugador : MonoBehaviour
{

    [SerializeField] private float vida;
    [SerializeField] private float VidaMaxima;
    [SerializeField] private BarraDeVida barraDeVida;
    //private Movimiento_Jugador movimientojugador;
    [SerializeField] private float tiempoPerdidaControl;


    private void Start()
    {

        vida = VidaMaxima;


       // movimientojugador = GetComponent<Movimiento_Jugador>();


        barraDeVida.InicializarBarraDeVida(vida);
    }

    public void TomarDaño(float daño, Vector2 posicion)
    {

        vida -= daño;
        StartCoroutine(PerderControl());
        StartCoroutine(DesactivarColision());
        //movimientojugador.Rebote(posicion);
        barraDeVida.CambiarVidaActual(vida);
        
        if(vida <= 0)
        {

            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }

    private IEnumerator PerderControl()
    {
        //movimientojugador.sePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        //movimientojugador.sePuedeMover = true;

    }

    private IEnumerator DesactivarColision()
    {
        Physics2D.IgnoreLayerCollision(7,8,true);
        yield return new WaitForSeconds(tiempoPerdidaControl);
        Physics2D.IgnoreLayerCollision(7, 8, false);

    }
}
