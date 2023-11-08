using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviminetoAlumno : MonoBehaviour
{
    public float velocidad = 2.0f;
    public bool dir;
    public Transform InitPos;
    // Start is called before the first frame update
    void Start()
    {
        InitPos = GetComponent<Transform>();
        InitPos.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       

        if(transform.position.x>0) { transform.Translate(Vector3.left * velocidad * Time.deltaTime); }
        else  { transform.Translate(Vector3.right * velocidad * Time.deltaTime); };
       
        
    }
}
