using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: Header("References")]
    [field: SerializeField] public PlayerSO Data {get; private set;}

    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public CharacterController CharacterController { get; private set; }
    public PlayerInput Input { get; private set; }

    private PlayerStateMachine playerStateMachine; 

    private void Awake()
    {
        AnimationData.Initialize();

        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        CharacterController = GetComponent<CharacterController>();
        Input = GetComponent<PlayerInput>();

        playerStateMachine = new PlayerStateMachine(this); 
    }

    private void Start()
    {
        playerStateMachine.ChangeState(playerStateMachine.IdleState);
    }

    private void Update()
    {
        playerStateMachine.HandleInput();
        playerStateMachine.Update();
    }
    private void FixedUpdate()
    {
        playerStateMachine.PhysicsUpdate();
    }
}