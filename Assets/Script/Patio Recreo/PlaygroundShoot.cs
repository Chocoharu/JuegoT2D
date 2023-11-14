using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlaygroundShoot : MonoBehaviour
{
    public int Score;
    public TextMeshProUGUI TextoScore;
    public static PlaygroundShoot Instance;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        if(Instance != null)
        {
            Destroy(gameObject);
            
        }
        
    }

    
    public void AddPoint(int points)
    {
        Score += points;
        TextoScore.text = "Puntaje: " + Score;
    }
    public void RemovePoint(int points)
    {
        Score -= points;
        if(Score<0)
        {
            Score = 0;
        }
        TextoScore.text = "Puntaje: " + Score;
    }

    // Update is called once per frame
    void Update()
    {
       //TextoScore.text = "Puntaje: " + Score;
    }
    
    public int Puntaje()
    { return Score; }
}
