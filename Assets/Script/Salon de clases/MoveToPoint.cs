using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveToPoint : MonoBehaviour
{

    public Transform TargetPos;
    public Transform TargetPos2;
    public Transform TargetPos3;
    public Transform TargetPos4;
    public float speed = 5;
    public bool flag = true;
    private bool flag2 = false;
    private bool flag3 = true;

    public ActivarPanel empezarEscribir;
    public GameObject Pause;
    public GameObject BtnPause;
    private bool paused = false;

    public GameObject PowEj;
    public GameObject StudentEj;
    public GameObject Dialog;
    public SpriteRenderer RealStudent;
    public GameObject EjNoise;



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
                Destroy(StudentEj);
                Color colorActual = RealStudent.color;
                colorActual.a = 1;
                RealStudent.color = colorActual;

                Destroy(Dialog);
                Destroy(EjNoise);
                PowEj.SetActive(true);
                Destroy(PowEj, 0.5f);
            }
        }
        if (flag2 && flag3)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPos3.position, speed * Time.deltaTime);
            if(transform.position == TargetPos3.position)
            {
                flag3 = false;
            }
        }
        if (!flag3)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPos4.position, speed * Time.deltaTime);
            if (transform.position == TargetPos4.position && !paused)
            {
                Pause.SetActive(false);
                BtnPause.SetActive(true);
                paused = true;
            }
        }
    }
}
