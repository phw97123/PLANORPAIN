using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Android;

public class Cat : MonoBehaviour
{
    private NavMeshAgent agent;

    private const float RandomDestinationRadius = 10f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //경로 계산을 하고 있지 않고, 목적지에 거의 도착했다면 ( remainingDistance은 정확한 0을 잡지 못함 )  
        if (!agent.pathPending && agent.remainingDistance<0.5f)
        {
            SetRandomDestination();
        }
    }

    private void SetRandomDestination()
    {
        Vector3 randomPos = RandomNavMeshPosition(RandomDestinationRadius); 
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
