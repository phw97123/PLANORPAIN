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