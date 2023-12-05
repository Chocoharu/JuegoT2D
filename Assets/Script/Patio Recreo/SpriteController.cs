using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    public Sprite Estudiante1;
    public Sprite Estudiante2;
    public Sprite Estudiante3;
    public Sprite Estudiante4;
    public SpriteRenderer Apariencia;
    private int Selector;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Apariencia = GetComponent<SpriteRenderer>();
        Selector = Random.Range(0, 4);
        if(Selector==0)
        {
            Apariencia.sprite = Estudiante1;
        }
        else if(Selector==1)
        {
            Apariencia.sprite= Estudiante2;
        }
        else if(Selector==2)
        {
            Apariencia.sprite = Estudiante3;
        }
        else
        {
            Apariencia.sprite = Estudiante4;
            //animator.SetBool("Caminar", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
