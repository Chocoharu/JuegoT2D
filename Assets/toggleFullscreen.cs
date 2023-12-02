using UnityEngine;

public class ToggleFullscreen : MonoBehaviour
{
    private bool isFullscreen = true; // Inicialmente, asumimos que estamos en modo pantalla completa

    void Start()
    {
        // Configurar el estado inicial
        UpdateFullscreenState();
    }

    // Función llamada por el botón de alternancia
    public void ToggleFullscreenMode()
    {
        isFullscreen = !isFullscreen;
        UpdateFullscreenState();
    }

    // Actualizar el estado de pantalla completa
    private void UpdateFullscreenState()
    {
        Screen.fullScreen = isFullscreen;

        // Si estás en modo de ventana, puedes ajustar el tamaño de la ventana como desees
        if (!isFullscreen)
        {
            // Ajusta estos valores según tus preferencias
            Screen.SetResolution(800, 600, false);
        }
    }
}
