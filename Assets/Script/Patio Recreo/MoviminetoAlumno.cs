using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviminetoAlumno : MonoBehaviour
{
    public float velocidad = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      
       if(transform.position.x>0) { transform.Translate(Vector2.left * velocidad * Time.deltaTime); }
       else if(transform.position.x <= 0) { transform.Translate(Vector2.right * velocidad * Time.deltaTime); }
        
    }
}
