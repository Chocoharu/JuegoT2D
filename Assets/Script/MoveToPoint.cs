using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour
{

    public Transform TargetPos;
    public Transform TargetPos2;
    public Transform TargetPos3;
    public float speed = 5;
    public bool flag = true;
    public bool flag2 = false;
    public ActivarPanel empezarEscribir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetPos != null && flag)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPos.position, speed * Time.deltaTime);
            if (transform.position == TargetPos.position)
            {
                empezarEscribir.Empezar();
            }
        }
        if (!flag && !flag2)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPos2.position, speed * Time.deltaTime);
            if(transform.position == TargetPos2.position)
            {
                flag2 = true;
            }
        }
        if (flag2)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPos3.position, speed * Time.deltaTime);
        }
    }
}
