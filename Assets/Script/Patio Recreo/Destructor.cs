using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destructor : MonoBehaviour
{
    public GameObject Pause;
    public MedidorDirector barraDirector;
    [SerializeField] private int flag = 4;
    public GameObject[] next;//siguientes en el tutorial
    public GameObject BtnPause;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (flag < 3)
        {
            Destroy(next[flag]);

            if (flag + 1 < next.Length)
            {
                next[flag + 1].SetActive(true);
            }
            
            flag++;
        }
        if (collision.CompareTag("AveEjemplo"))
        {
            Debug.Log("colision");
            Pause.SetActive(false);
            barraDirector.Reset();
            PlaygroundShoot.Instance.Reset();
            
            BtnPause.SetActive(true);
        }

        Destroy(collision.gameObject);
    }
}
