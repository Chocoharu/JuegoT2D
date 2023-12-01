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

    public void Reset()
    {
        Score = 0;
        TextoScore.text = "Puntaje: " + Score;
    }
    public void AddPoint(int points)
    {
        Score += points;
        TextoScore.text = "Puntaje: " + Score;
        PlayerPrefs.SetInt("Puntaje", Score);
        PlayerPrefs.Save();
    }
    public void RemovePoint(int points)
    {
        Score -= points;
        if(Score<0)
        {
            Score = 0;
        }
        TextoScore.text = "Puntaje: " + Score;
        PlayerPrefs.SetInt("Puntaje", Score);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public int Puntaje()
    { return Score; }
}
