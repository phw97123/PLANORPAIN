using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AIState
{
    Idle,
    Wandering
}

public class NPCConvenienceStore : MonoBehaviour
{
    [Header("Stats")]
    public float walkSpeed;
    public float rotationSpeed;

    [Header("AI")]
    private AIState aiState;
    public float detectDistance;

    [Header("Wandering")]
    public float minWanderDistance;
    public float maxWanderDistance;
    public float minWanderWaitTime;
    public float maxWanderWaitTime;

    private float _playerDistance;
    private int _walkParameterHash;

    private ConvenienceStoreGameManager _convenienceStoreGame;
    private GameObject _player;
    private NavMeshAgent _agent;
    private Animator _animator;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();

        _walkParameterHash = Animator.StringToHash("walk");
    }
    private void Start()
    {
        _convenienceStoreGame = ConvenienceStoreGameManager.Instance;

        SetState(AIState.Wandering);
        _agent.speed = walkSpeed;
        _player = _convenienceStoreGame.Player;
    }
    private void SetState(AIState newState)
    {
        aiState = newState;
        float animSpeed = 1;
        switch (aiState)
        {
            case AIState.Idle:
                {
                    _animator.SetBool(_walkParameterHash, false);
                    _agent.isStopped = true;
                }
                break;
            case AIState.Wandering:
                {
                    animSpeed = walkSpeed;
                    _animator.SetBool(_walkParameterHash, true);
                    _agent.isStopped = false;
                }
                break;
        }

        _animator.speed = _agent.speed * animSpeed;
    }
    private void Update()
    {
        if(_player)
        {
            _playerDistance = Vector3.Distance(transform.position, _player.transform.position);
            if (_playerDistance > detectDistance) _convenienceStoreGame.isWithinNPCZone = false;
            else _convenienceStoreGame.isWithinNPCZone = true;
        }

        PassiveUpdate();
    }

    private void PassiveUpdate()
    {
        if (aiState == AIState.Wandering && _agent.remainingDistance < 0.1f)
        {
            SetState(AIState.Idle);
            Invoke("WanderToNewLocation", Random.Range(minWanderWaitTime, maxWanderWaitTime));
        }

        Vector3 targetDirection = (_agent.destination - transform.position).normalized;
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    void WanderToNewLocation()
    {
        if (aiState != AIState.Idle)
        {
            return;
        }
        SetState(AIState.Wandering);
        _agent.SetDestination(GetWanderLocation());
    }

    Vector3 GetWanderLocation()
    {
        NavMeshHit hit;

        NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * Random.Range(minWanderDistance, maxWanderDistance)), out hit, maxWanderDistance, NavMesh.AllAreas);

        int i = 0;
        while (Vector3.Distance(transform.position, hit.position) < detectDistance)
        {
            NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * Random.Range(minWanderDistance, maxWanderDistance)), out hit, maxWanderDistance, NavMesh.AllAreas);
            i++;
            if (i == 30)
                break;
        }

        return hit.position;
    }
}
