using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    public float Speed;
    private Animator animator;
    private int Dir = 0;
    public bool CanMove = true;

    public GameObject Pausa;
    public Pause pause;
    //[SerializeField] private bool dialog = true; // si existe algun dialogo activarlo

    private bool sobreCanica = false;
    private float velocidadDeslizamiento = 10.0f;
    private Vector2 direccionOriginal;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Pausa != null)
            {
                if (Pausa.activeSelf)
                {
                    return;
                }
            }

        if (Input.GetKey(KeyCode.Escape))
        {
            pause.SpecialPause();
        }

        if (sobreCanica)
        {
            rigidbody.velocity = direccionOriginal * velocidadDeslizamiento;
        }
        else
        {
            if (Input.GetKey(KeyCode.W) && CanMove)
            {
                direccionOriginal = transform.up;
                rigidbody.velocity = direccionOriginal * Speed;
                Dir = 3;
            }
            else if (Input.GetKey(KeyCode.S) && CanMove)
            {
                direccionOriginal = -transform.up;
                rigidbody.velocity = direccionOriginal * Speed;
                Dir = 1;
            }
            else if (Input.GetKey(KeyCode.D) && CanMove)
            {
                direccionOriginal = transform.right;
                rigidbody.velocity = direccionOriginal * Speed;
                rigidbody.velocity = transform.right * Speed;
                Dir = 2;
                transform.localScale = new Vector2(1, 1);
            }
            else if (Input.GetKey(KeyCode.A) && CanMove)
            {
                direccionOriginal = -transform.right;
                rigidbody.velocity = direccionOriginal * Speed;
                Dir = 2;
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                Dir = 0;
                rigidbody.velocity = Vector3.zero;
            }
            animator.SetInteger("Movement", Dir);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Mancha"))
        {
            Speed = 3;
        }
        if (collision.CompareTag("Canica"))
        {
            // Si estamos sobre una "Canica", activamos el deslizamiento
            StartCoroutine(Deslizarse());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mancha"))
        {
            Speed = 8;
        }
    }
    public void Stunned()
    {
        CanMove = false;
        StartCoroutine("EsperarYCambiarEstado", 1.25f);
        //EsperarYCambiarEstado();
    }
    public IEnumerator EsperarYCambiarEstado()
    {
        yield return new WaitForSeconds(0.5f);
        CanMove = true;
    }
    private IEnumerator Deslizarse()
    {
        sobreCanica = true;
        animator.SetInteger("Resbalon", Dir);
        // Esperamos un tiempo arbitrario, puedes ajustar según sea necesario
        yield return new WaitForSeconds(1.0f);

        // Desactivamos el deslizamiento
        sobreCanica = false;
        animator.SetInteger("Resbalon", 0);
    }
}
