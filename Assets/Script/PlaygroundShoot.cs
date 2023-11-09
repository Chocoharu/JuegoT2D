using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlaygroundShoot : MonoBehaviour
{
    public int Score;
    public TextMeshPro TextoScore;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (CompareTag("Estudiante"))
        {
            Score += 100;
            TextoScore.text = "Puntaje" + Score;
            Destroy(gameObject);
        }
        else if(CompareTag("Ave"))
        {

        }
           
    }
    public int Puntaje()
    { return Score; }
}
