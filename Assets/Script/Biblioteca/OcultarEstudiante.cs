using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        OriginalPosition = transform.position;
        timer = Random.Range(2.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!escondido)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                if (!returning)
                {
                    MoveToPosition();
                }
            }
        }
    }

    void MoveToPosition()
    {
        if (TargetPosition == null)
        {
            TargetPosition = GetRandomTargetPosition();
        }

        transform.position = Vector2.MoveTowards(transform.position, TargetPosition.position, speed * Time.deltaTime);

        if (transform.position == TargetPosition.position)
        {
            timer = Random.Range(3.0f, 4.0f);
            escondido = true;
            this.GetComponent<SpriteRenderer>().sortingOrder = -1;
            TargetPosition = null;
        }
    }
    public void ReturnToOriginalPosition()
    {
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
    }
}
