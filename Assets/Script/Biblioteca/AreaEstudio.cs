using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AreaEstudio : MonoBehaviour
{
    public int score = 0;
    public float scoreRate = 10.0f;
    public int Porcent = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI PorcentText;

    private float timer = 0.0f;
    public float timeToIncreaseScore = 2.0f;

    public List<Collider2D> Estudiantes = new List<Collider2D>();

    public GameObject Pause;

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Pause != null)
        {
            if (Pause.activeSelf)
            {
                return;
            }
        }

        PorcentText.text = "Aprendizaje: " + Porcent + "%";
        scoreText.text = "Puntaje: " + score;
        PlayerPrefs.SetInt("Puntaje", score);
        PlayerPrefs.SetInt("Aprendizaje", Porcent);
        PlayerPrefs.Save();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Estudiante"))
        {
            Estudiantes.Add(collision);
            timeToIncreaseScore -= 0.25f;
            if(timeToIncreaseScore <1f)
            {
                timeToIncreaseScore = 1f;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Estudiante"))
        {

            timer += Time.deltaTime;
            if (timer >= timeToIncreaseScore && Estudiantes.Count != 0)
            {
                IncreaseScore();
                timer = 0.0f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Estudiante"))
        {
            Estudiantes.Remove(collision);
            timeToIncreaseScore += 0.25f;
            if (timeToIncreaseScore > 3f)
            {
                timeToIncreaseScore = 3f;
            }
        }
    }

    private void IncreaseScore()
    {
        score += Mathf.RoundToInt(scoreRate);
        Porcent += 2;
        if(Porcent > 100)
        {
            Porcent = 100;
        }
    }
    public int Porcentaje()
    { return Porcent; }
}
