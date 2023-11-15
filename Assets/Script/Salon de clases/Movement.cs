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

    public GameObject Pause;
    [SerializeField] private bool dialog = true; // si existe algun dialogo activarlo

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialog == true)
        {
            if (Pause.activeSelf)
            {
                return;
            }
        }

        if (Input.GetKey(KeyCode.W) && CanMove)
        {
            rigidbody.velocity = transform.up * Speed;
            Dir = 1;
            //transform.position += Vector3.right * Time.deltaTime * Speed;
        }
        else if (Input.GetKey(KeyCode.S) && CanMove)
        {
            rigidbody.velocity = -transform.up * Speed;
            Dir = 3;
            //transform.position -= Vector3.right * Time.deltaTime * Speed;
        }
        else if (Input.GetKey(KeyCode.D) && CanMove)
        {
            rigidbody.velocity = transform.right * Speed;
            Dir = 4;
            transform.localScale = new Vector3(1, 1, 1);
            //transform.position += Vector3.right * Time.deltaTime * Speed;
        }
        else if (Input.GetKey(KeyCode.A) && CanMove)
        {
            rigidbody.velocity = -transform.right * Speed;
            Dir = 2;
            transform.localScale = new Vector3(-1, 1, 1);
            //transform.position -= Vector3.right * Time.deltaTime * Speed;
        }
        else
        {
            Dir = 0;
            rigidbody.velocity = Vector3.zero;
        }
        animator.SetInteger("Movement", Dir);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Mancha"))
        {
            Speed = 2;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mancha"))
        {
            Speed = 4;
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
}
