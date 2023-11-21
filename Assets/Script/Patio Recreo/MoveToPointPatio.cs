using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPointPatio : MonoBehaviour
{
    public Transform TargetPos;
    public Transform TargetPos2;
    //public Transform TargetPos3;
    //public Transform TargetPos4;
    public float speed = 2;
    public bool flag = true;
    public bool flag2 = false;
    //public bool flag3 = true;

    //public ActivarPanel empezarEscribir;
    public GameObject Pause;
    public GameObject next;

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
                flag = false;
                if(next != null)
                {
                    next.SetActive(true);
                }
            }
        }
        /*if (TargetPos2 != null && flag2)
        {
            if (next != null)
            {
                next.SetActive(true);
            }
        }*/
    }
}
