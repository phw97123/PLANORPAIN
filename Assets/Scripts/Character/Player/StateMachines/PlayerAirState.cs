using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerBaseState
{
    public PlayerAirState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(playerStateMachine.Player.AnimationData.AirParatmeterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(playerStateMachine.Player.AnimationData.AirParatmeterHash);
    }
}