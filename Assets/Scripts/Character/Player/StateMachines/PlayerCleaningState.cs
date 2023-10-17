using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCleaningState : PlayerGroundState
{
    public PlayerCleaningState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        playerStateMachine.MovementSpeedModifier = groundData.WalkSpeedModifier;
        base.Enter();
        StartAnimation(playerStateMachine.Player.AnimationData.CleaningParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(playerStateMachine.Player.AnimationData.CleaningParameterHash); 
    }
}
