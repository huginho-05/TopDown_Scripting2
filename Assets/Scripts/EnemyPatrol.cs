using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;

    [Header("Movimiento")]
    public float moveSpeed = 2f;

    [Header("Espera")]
    public float waitTime = 2f;

    private NavMeshAgent agent;
    private int currentPoint = 0;
    private bool waiting = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Velocidad del NPC
        agent.speed = moveSpeed;

        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[currentPoint].position);
        }
    }

    void Update()
    {
        if (patrolPoints.Length == 0 || waiting)
            return;

        if (!agent.pathPending &&
            agent.remainingDistance <= agent.stoppingDistance)
        {
            StartCoroutine(WaitAndMove());
        }
    }

    IEnumerator WaitAndMove()
    {
        waiting = true;

        // Detiene el movimiento
        agent.isStopped = true;

        yield return new WaitForSeconds(waitTime);

        // Siguiente punto
        currentPoint = (currentPoint + 1) % patrolPoints.Length;

        agent.SetDestination(patrolPoints[currentPoint].position);
        agent.isStopped = false;

        waiting = false;
    }
}
