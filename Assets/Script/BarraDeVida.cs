using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{

    private Slider slider;

    private void Start()
    {

        slider = GetComponent<Slider>();
    }

    public void CambiarVidaMaxima(float VidaMaxima)
    {

        slider.maxValue = VidaMaxima;
    }

    public void CambiarVidaActual(float cantidadVida)
    {

        slider.value = cantidadVida;
    }

    public void InicializarBarraDeVida(float cantidadVida)
    {

        CambiarVidaMaxima(cantidadVida);
        CambiarVidaActual(cantidadVida);
    }
}
