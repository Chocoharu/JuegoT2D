using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MedidorDirector : MonoBehaviour
{

    private Slider slider;
    public static MedidorDirector instance;
    public Texture2D cursorTextureNormal;  // Asigna el sprite normal del cursor en el Inspector
    public Texture2D cursorTextureClick;   // Asigna el sprite del cursor al hacer clic en el Inspector
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    private bool clicPresionado = false;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        slider = GetComponent<Slider>();
        CambiarCursorEnEscena(cursorTextureNormal);
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
        if (Input.GetMouseButtonDown(0) && !clicPresionado)
        {
            clicPresionado = true;
            CambiarCursorEnEscena(cursorTextureClick);
        }

        // Restaurar el cursor al soltar el clic
        if (Input.GetMouseButtonUp(0) && clicPresionado)
        {
            clicPresionado = false;
            CambiarCursorEnEscena(cursorTextureNormal);
        }
    }
    void CambiarCursorEnEscena(Texture2D cursorTexture)
    {
        // Cambia el cursor utilizando los parámetros proporcionados
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
}
