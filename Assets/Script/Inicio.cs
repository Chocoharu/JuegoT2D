using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{
    private string escenaInicial = "Inicio";
    // Start is called before the first frame update
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Salir()
    {
        Application.Quit();
    }

    public void Return()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
    public void ReturnAsset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }
    public void GoAsset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
    public void RegresarEscenaAnterior()
    {

        string escenaAnterior = PlayerPrefs.GetString("EscenaAnterior", escenaInicial);

        // Obtener el nombre de la escena anterior almacenada
        /*if (SceneManager.GetActiveScene().name == "Juego")
        {
            escenaAnterior = PlayerPrefs.GetString("Juego", escenaInicial);
        }
        else if(SceneManager.GetActiveScene().name == "Patio")
        {
            escenaAnterior = PlayerPrefs.GetString("Patio", escenaInicial);
        }
        else if (SceneManager.GetActiveScene().name == "Biblioteca")
        {
            escenaAnterior = PlayerPrefs.GetString("Biblioteca", escenaInicial);
        }*/
        // Cargar la escena anterior
        SceneManager.LoadScene(escenaAnterior);
    }
    public void NextSceneVictory()
    {
        string escenaAnterior = PlayerPrefs.GetString("EscenaAnterior", escenaInicial);
        if(escenaAnterior == "Juego")
        {
            SceneManager.LoadScene("Patio");
        }
        else if (escenaAnterior == "Patio")
        {
            SceneManager.LoadScene("Biblioteca");
        }
        else if (escenaAnterior == "Biblioteca")
        {
            //SceneManager.LoadScene("Biblioteca");
            Application.Quit();
        }
    }
}
