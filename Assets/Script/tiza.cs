using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiza : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        /*if (collision.gameObject.CompareTag("alumno")){
            Destroy(this.gameObject);
        }*/
    }
}
