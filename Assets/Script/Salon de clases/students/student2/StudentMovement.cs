using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StudentMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2.0f;
    private int currentWaypoint = 0;
    private bool isMoving = true;
    private NavMeshAgent navMeshAgent;

    public GameObject Pause;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.speed = speed;
        SetWaypoints();
    }

    void Update()
    {
        if (Pause.activeSelf)
        {
            return;
        }
        if (isMoving && GetComponent<Alerta>().permisoGolpe)
        {
            MoveToWaypoint();
        }
    }

    void MoveToWaypoint()
    {
        if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            SetDestination(waypoints[currentWaypoint].position);
        }
    }

    void SetDestination(Vector3 destination)
    {
        navMeshAgent.SetDestination(destination);
    }

    void SetWaypoints()
    {
        // Set waypoints as NavMeshAgent destinations
        navMeshAgent.SetDestination(waypoints[currentWaypoint].position);
    }

    public void ReturnToSeat()
    {
        isMoving = false;
        currentWaypoint = 0;
        SetDestination(waypoints[currentWaypoint].position);
    }

    public void StartMoving()
    {
        isMoving = true;
    }
}
