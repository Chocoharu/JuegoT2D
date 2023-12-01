using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    public GameObject Pause;
    public MedidorDirector barraDirector;
    private bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AveEjemplo") && flag)
        {
            Debug.Log("colision");
            Pause.SetActive(false);
            barraDirector.Reset();
            PlaygroundShoot.Instance.Reset();
            flag = false;
        }
        Destroy(collision.gameObject);
    }
}
