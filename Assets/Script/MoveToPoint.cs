using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour
{

    public Transform TargetPos;
    public Transform TargetPos2;
    public float speed = 5;
    public bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flag)
        {
            if (TargetPos != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, TargetPos.position, speed * Time.deltaTime);
            }
        }
        else
        {
            if (TargetPos2 != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, TargetPos2.position, speed * Time.deltaTime);
            }
        }
        
        
    }
}