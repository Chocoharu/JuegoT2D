using System.Collections;
using UnityEngine;

public class Student3 : MonoBehaviour
{
    public GameObject marblePrefab;
    public LayerMask playerLayer;
    public float marbleLifetime = 5f;
    
    public int numberOfMarbles = 2; // Número de canicas a generar
    public float radius = 1.5f; // Radio de la circunferencia

    public bool isSlippery = false;
    private float marbleTimer;

    public GameObject Pause;
    
    private void Start()
    {
        // Inicializamos el temporizador para lanzar las canicas
        marbleTimer = Random.Range(3f, 9f);
    }

    private void Update()
    {
        if (Pause != null)
        {
            if (Pause.activeSelf)
            {
                return;
            }
        }
        // Reducimos el temporizador en cada frame
        marbleTimer -= Time.deltaTime;

        if (marbleTimer <= 0 && !isSlippery)
        {
            // Lanzamos las canicas y reiniciamos el temporizador
            ThrowMarbleRing();
            marbleTimer = Random.Range(3f, 9f);
        }
    }

    private void ThrowMarbleRing()
    {
        for (int i = 0; i < numberOfMarbles; i++)
        {
            float angle = i * 2 * Mathf.PI / numberOfMarbles;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            Vector2 spawnPosition = (Vector2)transform.position + direction * radius;

            GameObject marble = Instantiate(marblePrefab, spawnPosition, Quaternion.identity);
            Rigidbody2D marbleRb = marble.GetComponent<Rigidbody2D>();
            marbleRb.AddForce(direction * 5f, ForceMode2D.Impulse);
            Destroy(marble, marbleLifetime);
        }
    }

    // Método para visualizar la circunferencia en el Editor de Unity
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        for (int i = 0; i < numberOfMarbles; i++)
        {
            float angle = i * 2 * Mathf.PI / numberOfMarbles;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            Vector2 spawnPosition = (Vector2)transform.position + direction * radius;
            Gizmos.DrawWireSphere(spawnPosition, 0.1f);
        }
    }
}
