using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{
    private string escenaInicial = "Inicio";
    public TextMeshProUGUI bottonText;
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
        SceneManager.LoadScene(escenaAnterior);
    }
    public void NextSceneVictory()
    {
        string escenaAnterior = PlayerPrefs.GetString("EscenaAnterior", escenaInicial);
        if(escenaAnterior == "Juego")
        {
            SceneManager.LoadScene("Biblioteca");
        }
        else if (escenaAnterior == "Biblioteca")
        {
            SceneManager.LoadScene("Patio");
        }
        else if (escenaAnterior == "Patio")
        {
            SceneManager.LoadScene("juego2");
        }
        else if (escenaAnterior == "juego2")
        {
            SceneManager.LoadScene("Biblioteca2");
        }
        else if(escenaAnterior == "Biblioteca2")
        {
            bottonText.text = "Salir";
            Application.Quit();
        }
    }
}
