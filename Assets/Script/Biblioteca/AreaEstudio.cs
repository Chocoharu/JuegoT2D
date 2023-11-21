using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AreaEstudio : MonoBehaviour
{
    public int score = 0;
    public float scoreRate = 10.0f;
    public TextMeshProUGUI scoreText;

    private float timer = 0.0f;
    public float timeToIncreaseScore = 2.0f;

    public List<Collider2D> Estudiantes = new List<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer >= timeToIncreaseScore && Estudiantes.Count!=0)
        {
            IncreaseScore();
            timer = 0.0f;
        }

        scoreText.text = "Score: " + score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Estudiante"))
        {
            Estudiantes.Add(collision);
            timeToIncreaseScore -= 0.25f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Estudiante"))
        {
            //score += 10;//Mathf.RoundToInt(scoreRate * Time.deltaTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Estudiante"))
        {
            Estudiantes.Remove(collision);
            timeToIncreaseScore += 0.25f;
        }
    }

    private void IncreaseScore()
    {
        score += Mathf.RoundToInt(scoreRate);
    }
}
