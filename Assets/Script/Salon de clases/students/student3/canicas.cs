using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canicas : MonoBehaviour
{
    public GameObject Student;
    public float slipForce = 5f;
    public Transform playerTransform;
    private bool slip = true;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && slip)
        {
            Debug.Log("enter");
            //Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>(); 
            StartCoroutine(SlipPlayer(playerTransform));
            slip = false;
        }
    }

    private IEnumerator SlipPlayer(Transform playerTransform)
    {
        //isSlippery = true;

        float currentSpeed = 0f;
        float acceleration = 5f;  

        // Determinar la direcci�n en funci�n de la posici�n inicial
        Vector2 direction = (playerTransform.position.x < 0) ?  Vector2.right : Vector2.left;

        while (currentSpeed < slipForce)
        {
            currentSpeed += acceleration * Time.deltaTime;
            playerTransform.Translate(direction * currentSpeed * Time.deltaTime, Space.World);
            yield return null;
        }

        // Continuar aumentando la velocidad hasta que colisione con algo o pasado un tiempo l�mite
        float maxSlipDuration = 3.5f;  // Ajusta el tiempo l�mite seg�n tus necesidades
        float timer = 0f;

        while (timer < maxSlipDuration)
        {
            playerTransform.Translate(direction * currentSpeed * Time.deltaTime, Space.World);

            // Verificar si ha colisionado con algo
            Collider2D[] colliders = Physics2D.OverlapCircleAll(playerTransform.position, 1f); // Ajusta el radio seg�n tus necesidades

            if (HasCollision(colliders))
            {
                break; // Salir del bucle cuando hay una colisi�n
            }

            timer += Time.deltaTime;
            slip = true;
            yield return null;
        }

        //isSlippery = false;
    }

    // Funci�n auxiliar para verificar si hay alguna colisi�n v�lida
    private bool HasCollision(Collider2D[] colliders)
    {
        foreach (Collider2D collider in colliders)
        {
            // Verificar si es una colisi�n v�lida (puedes ajustar las condiciones seg�n tus necesidades)
            if (collider.gameObject != gameObject)
            {
                Debug.Log("break");
                slip = true;

                return true;
            }
        }
        return false;
    }



}
