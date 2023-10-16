using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundShiverState : GroundBaseState
{
    public GroundShiverState(GroundStateMachine groundStateMachine) : base(groundStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(groundStateMachine.Ground.AnimationData.ShiverParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(groundStateMachine.Ground.AnimationData.ShiverParameterHash);
    }

    public override void Update()
    {
        base.Update();
    }
}
