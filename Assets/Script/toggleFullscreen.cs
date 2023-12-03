using UnityEngine;

public class ToggleFullscreen : MonoBehaviour
{
    private bool isFullscreen = true; // Inicialmente, asumimos que estamos en modo pantalla completa

    void Start()
    {
        // Configurar el estado inicial
        UpdateFullscreenState();
    }

    // Funci�n llamada por el bot�n de alternancia
    public void ToggleFullscreenMode()
    {
        isFullscreen = !isFullscreen;
        UpdateFullscreenState();
    }

    // Actualizar el estado de pantalla completa
    private void UpdateFullscreenState()
    {
        Screen.fullScreen = isFullscreen;

        // Si est�s en modo de ventana, puedes ajustar el tama�o de la ventana como desees
        if (!isFullscreen)
        {
            // Ajusta estos valores seg�n tus preferencias
            Screen.SetResolution(800, 600, false);
        }
    }
}
