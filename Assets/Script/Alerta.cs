using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Alerta : MonoBehaviour
{
    public GameObject prefab;
    public bool permisoGolpe;
    private Animator animator;
    private float Timer;
    bool Existe = false;
    GameObject spriteGenerado = null;
    public Transform profe;

    public GameObject Pause;
    [SerializeField] private bool dialog = true; // si existe algun dialogo activarlo

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Inquieto", false);
        Timer = Random.Range(3.0f, 9.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (dialog == true)
        {
            if (Pause.activeSelf)
            {
                return;
            }
        }

        if (!Existe)
        {
            Timer -= Time.deltaTime;
        }
            
        if (Timer < 0 && !Existe)
        {
            animator.SetBool("Inquieto", true);
            spriteGenerado = Instantiate(prefab, transform.position + transform.up, Quaternion.identity);
            profe.GetComponent<Golpe>().CantAlertas();  
            permisoGolpe = true;
            Existe = true;
        }
    }
    public bool PermisoGolpe()
    {
        return permisoGolpe;
    }
    public void Destruir()
    {
        Destroy(spriteGenerado);
        permisoGolpe = false;
        animator.SetBool("Inquieto", false);
        Existe = false;
        Timer = Random.Range(3.0f, 9.0f);
    }
}
