using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour
{

    public Transform TargetPos;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetPos != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPos.position, speed*Time.deltaTime);
        }
    }
}
