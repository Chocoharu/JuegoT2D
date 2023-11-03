using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arm : MonoBehaviour
{
    public Transform arm1;
    public SpriteRenderer armR;
    public int speedTiza=10;
    Vector3 targetrotation;

    public GameObject tiza;
    Vector3 finalTarget;
    public int numtiza = 3;

    void Update()
    {
        targetrotation = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = MathF.Atan2(targetrotation.y, targetrotation.x) * Mathf.Rad2Deg;
        arm1.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if(angle > 90 || angle < -90)
            armR.flipY = true;
        else
            armR.flipY= false;

        if (Input.GetKeyDown(KeyCode.Mouse0) && numtiza > 0)
            shoot();
    }
    void shoot()
    {
        var Ball = Instantiate(tiza, arm1.position, transform.rotation, transform.parent);
        targetrotation.z = 0;
        finalTarget = (targetrotation - transform.position).normalized;
        Ball.GetComponent<Rigidbody2D>().AddForce(finalTarget * speedTiza, ForceMode2D.Impulse);
        numtiza--;
    }
}
