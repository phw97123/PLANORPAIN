using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [field: Header("Animation")]
    [field: SerializeField] public GroundAnimationData AnimationData { get; private set; } 

    public Animator Animator { get; private set; }

    public GroundStateMachine groundStateMachine { get; private set; }

    [field: SerializeField] public bool isShivering;
    [field: SerializeField] public bool isFalling;


    private void Awake()
    {
        AnimationData.Initialize();

        Animator = GetComponent<Animator>();

        groundStateMachine = new GroundStateMachine(this);
        isShivering = groundStateMachine.IsShivering;
    }

    private void Start()
    {
        groundStateMachine.ChangeState(groundStateMachine.IdleState);
    }

    private void Update()
    {
        groundStateMachine.Update();
        isShivering = groundStateMachine.IsShivering;
        if (isShivering)
        {
            StartCoroutine(ChangeToFallState());
        }
    }
    private void FixedUpdate()
    {
        groundStateMachine.PhysicsUpdate();
    }

    public void OnDestroyObject()
    {
        Destroy(groundStateMachine.Ground.gameObject);
    }

    IEnumerator ChangeToFallState()
    {
        yield return new WaitForSeconds(5f);
        isFalling = true;
        isShivering = false;
    }
}
