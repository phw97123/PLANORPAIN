using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }

    public PlayerIdleState IdleState {get;}
    public PlayerWalkState WalkState {get;}
    public PlayerRunState RunState { get; }
     public PlayerCleaningState CleaningState { get;}
    public PlayerComboAttackState ComboAttackState { get; }
    public PlayerJumpState JumpState { get; }
    public PlayerFallState FallState { get; }


    public Transform MainCameraTransform { get; set; }

    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;
    public float RotationDamping { get; private set; }

    public bool IsAttacking { get; set; }
    public int ComboIndex { get; set; }
    public int AttackTypeIndex { get; set; }
    public PlayerStateMachine(Player player)
    {
        this.Player = player;

        IdleState = new PlayerIdleState(this);
        WalkState = new PlayerWalkState(this);
        RunState = new PlayerRunState(this);
        CleaningState = new PlayerCleaningState(this);
        ComboAttackState = new PlayerComboAttackState(this);
        JumpState = new PlayerJumpState(this);

        MainCameraTransform = Camera.main.transform;

        MovementSpeed = player.Data.GroundData.BaseSpeed;
        RotationDamping = player.Data.GroundData.BaseRotationDamping;
    }
}
