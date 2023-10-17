using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Android;

public class Cat : MonoBehaviour
{
    private NavMeshAgent agent;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(!agent.pathPending && agent.remainingDistance<0.5f)
        {
            SetRandomDestination();
        }
    }

    private void SetRandomDestination()
    {
        Vector3 randomPos = RandomNavMeshPosition(10f); 
         agent.SetDestination(randomPos);
    }

    private Vector3 RandomNavMeshPosition(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit; 
        NavMesh.SamplePosition(randomDirection, out hit,radius,1);
        return hit.position; 
    }
}
