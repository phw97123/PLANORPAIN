using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        playerStateMachine.Player.Rigidbody.AddForce(Vector3.up  * playerStateMachine.Player.Data.AirData.JumpForce, ForceMode.Impulse);
        // 중력값과 복합적으로 영향받음. AddForce는 무게도 고려할 것,(보통 무게는 건들지는 않음)
        base.Enter();

        StartAnimation(playerStateMachine.Player.AnimationData.JumpParameterHash);
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(playerStateMachine.Player.AnimationData.JumpParameterHash);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (playerStateMachine.Player.Rigidbody.velocity.y <= 0)
        {
                playerStateMachine.ChangeState(playerStateMachine.IdleState);
        }       
    }
}