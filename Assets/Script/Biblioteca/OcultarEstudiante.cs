using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class OcultarEstudiante : MonoBehaviour
{
    public Transform[] Positions;
    private Transform NextPos;
    private int NextPosIndex;
    public float speed;
    private float RandPos;
    private float timer = 2.0f;
    public bool escondido = false;
    // Start is called before the first frame update
    void Start()
    {
        NextPos = this.transform;
        RandPos = Random.value;
        //this.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(RandPos >= 0.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, Positions[0].position, speed * Time.deltaTime);
            escondido = true;
            timer -= Time.deltaTime;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, Positions[1].position, speed * Time.deltaTime);
            escondido = true;
            timer -= Time.deltaTime;
        }
        if(escondido)
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = -1;
        }


        //if(timer < 0) { transform.position = Vector2.MoveTowards(transform.position, NextPos.position, speed * Time.deltaTime); }


        //MoveEstudent();
    }

    private void MoveEstudent()
    {
        if(transform.position == NextPos.position)
        {
            NextPosIndex++;
            if(NextPosIndex >= Positions.Length)
            {
                NextPosIndex = 0;
            }
            NextPos = Positions[NextPosIndex];
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, NextPos.position, speed * Time.deltaTime);
        }
    }
}
