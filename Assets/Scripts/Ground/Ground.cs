using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [field: Header("Animation")]
    [field: SerializeField] public GroundAnimationData AnimationData { get; private set; } // GroundAnimationData AnimationData

    public Animator Animator { get; private set; }

    public GroundStateMachine groundStateMachine { get; private set; }

    private void Awake()
    {
        groundStateMachine = GetComponent<GroundStateMachine>();
    }

    private void Start()
    {
        groundStateMachine.ChangeState(groundStateMachine.IdleState);
    }

    private void Update()
    {
        groundStateMachine.Update();
    }
    private void FixedUpdate()
    {
        groundStateMachine.PhysicsUpdate();
    }

    public void OnDestroyObject()
    {
        Destroy(groundStateMachine.Ground.gameObject);
    }
}
