using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ShootTarget : MonoBehaviour
{
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
            PlaygroundShoot.Instance.AddPoint(100);
            Destroy(gameObject);
            
        }
        
    }
}
