using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class student1 : MonoBehaviour
{
    public GameObject bolita;
    public Transform bolitaPos;
    public GameObject Pause;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause.activeSelf)
        {
            return;
        }
        timer += Time.deltaTime;
        if(timer > 3)
        {
            timer = 0;
            Shoot();
        }
    }
    public void Shoot()
    {
        Instantiate(bolita, bolitaPos.position, Quaternion.identity);
    }
}
