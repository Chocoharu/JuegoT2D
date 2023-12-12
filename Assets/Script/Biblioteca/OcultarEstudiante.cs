using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OcultarEstudiante : MonoBehaviour
{
    public Transform[] Positions;
    private Vector3 OriginalPosition;
    private Transform TargetPosition;
    public float speed;
    private float ReturnSpeed = 0.1f;
    private float timer;
    private bool returning = false;
    public bool escondido = false;
    public GameObject canicaPrefab;
    private GameObject currentCanica;
    private bool canCreateCanica = true;
    private bool destroyCanica = false;
    float randomProbability;
    private float maxProbability;

    public GameObject Pause;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        OriginalPosition = transform.position;
        timer = Random.Range(2.0f, 3.0f);
        if (SceneManager.GetActiveScene().name == "Biblioteca")
        {
            maxProbability = 8.0f;
        }
        else if (SceneManager.GetActiveScene().name == "Biblioteca2")
        {
            maxProbability = 6.0f;
        }
        randomProbability = Random.Range(1.0f, maxProbability);
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

        if (!escondido)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                if (!returning)
                {
                    animator.SetBool("Caminar", true);
                    MoveToPosition();
                }
            }
        }
        if(destroyCanica && currentCanica != null)
        {
            Destroy(currentCanica, 10.0f);
            destroyCanica = false;
        }
        if (IsInOriginalOrTargetPosition())
        {
            canCreateCanica = true;
            randomProbability = Random.Range(1.0f, maxProbability);
        }
    }

    void MoveToPosition()
    {
        float timerActivar = 5f;
        float timerDesactivar = 3f;

        if (TargetPosition == null)
        {
            TargetPosition = GetRandomTargetPosition();
        }

        transform.position = Vector2.MoveTowards(transform.position, TargetPosition.position, speed * Time.deltaTime);

        if (canCreateCanica && !IsInOriginalOrTargetPosition())
        {
            float distanceToOriginal = Vector2.Distance(transform.position, OriginalPosition);
            float minimumDistance = 3.0f;

            if (distanceToOriginal > minimumDistance)
            {
                if (randomProbability <= 3.0f)
                {
                    currentCanica = Instantiate(canicaPrefab, transform.position, Quaternion.identity);
                    canCreateCanica = false;
                    destroyCanica = true;
                }
            }
        }

        if (transform.position == TargetPosition.position)
        {
            animator.SetBool("Caminar", false);
            escondido = true;
            this.GetComponent<SpriteRenderer>().sortingOrder = -1;

            Animator animatorEstante = TargetPosition.GetComponent<Animator>();
            

            timerActivar -= Time.deltaTime;

            if (timerActivar <= 0)
            {
                animatorEstante.SetBool("Pista", true);
                timerDesactivar -= Time.deltaTime;
            }

            if (timerDesactivar <= 0)
            {
                animatorEstante.SetBool("Pista", false);
                timerActivar = 5f;
                timerDesactivar = 3.0f;            }
        }
    }
    public void ReturnToOriginalPosition()
    {
        TargetPosition = null;
        animator.SetBool("Caminar", true);
        escondido = false;
        this.GetComponent<SpriteRenderer>().sortingOrder = 0;
        StartCoroutine(MoveToOriginalPosition());
    }

    Transform GetRandomTargetPosition()
    {
        return Random.value > 0.5f ? Positions[0] : Positions[1];
    }
    IEnumerator MoveToOriginalPosition()
    {
        returning = true;
        float journeyLength = Vector2.Distance(transform.position, OriginalPosition);
        float startTime = Time.time;

        while (transform.position != OriginalPosition)
        {
            float distCovered = (Time.time - startTime) * ReturnSpeed;
            float fractionOfJourney = distCovered / journeyLength;

            transform.position = Vector2.Lerp(transform.position, OriginalPosition, fractionOfJourney);

            yield return null;
        }
        transform.position = OriginalPosition;

        TargetPosition = GetRandomTargetPosition();
        returning = false;
        if(transform.position == OriginalPosition)
        {
            animator.SetBool("Caminar", false);
        }
        
    }
    bool IsInOriginalOrTargetPosition()
    {
        return transform.position == OriginalPosition || (TargetPosition != null && transform.position == TargetPosition.position);
    }
}
