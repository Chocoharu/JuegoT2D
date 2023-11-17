using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MedidorDirector : MonoBehaviour
{

    private Slider slider;
    public static MedidorDirector instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        slider = GetComponent<Slider>();
    }
    public void CambiarVidaMaxima(float VidaMaxima)
    {

        slider.maxValue = VidaMaxima;
    }

    public void CambiarVidaActual(float cantidadVida)
    {

        slider.value += cantidadVida;
    }

    public void InicializarBarraDeVida(float cantidadVida)
    {

        CambiarVidaMaxima(cantidadVida);
        CambiarVidaActual(0);
    }
    private void Update()
    {
        if(slider.value==10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
