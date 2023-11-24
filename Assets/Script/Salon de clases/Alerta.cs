using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Alerta : MonoBehaviour
{
    public GameObject prefab;
    public GameObject Pow;
    public bool permisoGolpe;
    private Animator animator;
    private float Timer;
    bool Existe = false;
    GameObject spriteGenerado = null;
    GameObject spritePow = null;
    public Transform profe;

    public GameObject Pause;

    private bool isStunned = false;
    private float stunDuration = 2.75f;
    private float stunTimer = 0f;

    public bool SpecialStudent = false;
    public GameObject special;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //animator.SetBool("Inquieto", false);
        Timer = Random.Range(5.5f, 9.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause != null)
        {
            if (Pause.activeSelf)
            {
                return;
            }
        }

        if (!isStunned)
        {
            if (!Existe)
            {
                Timer -= Time.deltaTime;
            }

            if (Timer < 0 && !Existe)
            {
                // Check if not stunned before generating new alerts
                if (!isStunned)
                {
                    //animator.SetBool("Inquieto", true);
                    if (SpecialStudent)
                    {
                        special.SetActive(true);
                    }
                    else
                    {
                        spriteGenerado = Instantiate(prefab, transform.position + transform.up - transform.right, Quaternion.identity);
                    }
                    
                    profe.GetComponent<Golpe>().CantAlertas();
                    permisoGolpe = true;
                    Existe = true;
                    if (SpecialStudent)
                    {
                        // Llamar al método StartMoving del script StudentMovement
                        GetComponent<StudentMovement>().StartMoving();
                        Debug.Log("no normal");
                    }
                }
            }
        }
        else
        {
            // Handle stun timer
            stunTimer += Time.deltaTime;
            if (stunTimer >= stunDuration)
            {
                isStunned = false;
                stunTimer = 0f;
            }
        }
    }

    public bool PermisoGolpe()
    {
        return permisoGolpe && !isStunned;
    }

    public void ApplyStun()
    {
        isStunned = true;
        // Add any visual/audio effects for stun here, if necessary
    }
    public void Destruir()
    {
        if (!isStunned)
        {
            if (SpecialStudent)
            {
                special.SetActive(false);
            }
            else
            {
                Destroy(spriteGenerado);
            }
           
            spritePow = Instantiate(Pow, transform.position + transform.up , Quaternion.identity);
            Destroy(spritePow, 0.5f);
            permisoGolpe = false;
            //animator.SetBool("Inquieto", false);
            Existe = false;
            Timer = Random.Range(3.0f, 9.0f);

            if (SpecialStudent)
            {
                Debug.Log("normal");
                // Llamar al método ReturnToSeat del script StudentMovement
                GetComponent<StudentMovement>().ReturnToSeat();
            }
        }
    }
}
