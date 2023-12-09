using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transiciones : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip animacionFinal;
    public GameObject areaEstudio;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public IEnumerator CambiarEscena()
    {
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);

        if (SceneManager.GetActiveScene().name == "Juego" || SceneManager.GetActiveScene().name == "juego2")
        {
            string nombreEscenaActual = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("EscenaAnterior", nombreEscenaActual);
            PlayerPrefs.Save();

            SceneManager.LoadScene("FinalBueno");

        }
        /*if (SceneManager.GetActiveScene().name == "Patio")
        {
            string nombreEscenaActual = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("EscenaAnterior", nombreEscenaActual);
            PlayerPrefs.Save();

            SceneManager.LoadScene("FinalBueno");
        }*/
        if (SceneManager.GetActiveScene().name == "Biblioteca" || SceneManager.GetActiveScene().name == "Biblioteca2")
        {
            string nombreEscenaActual = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("EscenaAnterior", nombreEscenaActual);
            PlayerPrefs.Save();

            if (areaEstudio.GetComponent<AreaEstudio>().Porcentaje() > 50)
            {
                SceneManager.LoadScene("FinalBueno");
            }
            else
            {
                SceneManager.LoadScene("FinalMalo");
            }
        }
    }
}
