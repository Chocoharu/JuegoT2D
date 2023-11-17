using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desvanecer : MonoBehaviour
{
    // Start is called before the first frame update
    public float tiempoDeVida = 2.0f;
    public float velocidadDesvanecimiento = 1.0f;

    void Start()
    {
        StartCoroutine(DesvanecerYDestruir());
    }

    IEnumerator DesvanecerYDestruir()
    {
        yield return new WaitForSeconds(tiempoDeVida);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color opacidad = spriteRenderer.color;

        // Desvanecer gradualmente el objeto antes de destruirlo
        while (opacidad.a > 0)
        {
            opacidad.a -= velocidadDesvanecimiento * Time.deltaTime;
            spriteRenderer.color = opacidad;
            yield return null;
        }

        Destroy(gameObject);
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
