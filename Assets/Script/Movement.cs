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

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.velocity = transform.up * Speed;
            Dir = 1;
            //transform.position += Vector3.right * Time.deltaTime * Speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rigidbody.velocity = -transform.up * Speed;
            Dir = 3;
            //transform.position -= Vector3.right * Time.deltaTime * Speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = transform.right * Speed;
            Dir = 4;
            //transform.position += Vector3.right * Time.deltaTime * Speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = -transform.right * Speed;
            Dir = 2;
            //transform.position -= Vector3.right * Time.deltaTime * Speed;
        }
        else
        {
            Dir = 0;
            rigidbody.velocity = Vector3.zero;
        }
        animator.SetInteger("Movement", Dir);
    }
}