using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destructor : MonoBehaviour
{
    public GameObject Pause;
    public MedidorDirector barraDirector;
    //[SerializeField] private bool flag = true; 

    public GameObject BtnPause;

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
        if (collision.CompareTag("Ave") && SceneManager.GetActiveScene().name == "Patio")
        {
            Debug.Log("colision");
            Pause.SetActive(false);
            barraDirector.Reset();
            PlaygroundShoot.Instance.Reset();
            //flag = false;

            BtnPause.SetActive(true);
        }

        Destroy(collision.gameObject);
    }
}
