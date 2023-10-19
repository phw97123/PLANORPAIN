using UnityEngine;

public class GroundShiverState : GroundBaseState
{
    public GroundShiverState(GroundStateMachine groundStateMachine) : base(groundStateMachine)
    {
    }

    public bool countStart;
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
        //CountFiveSeconds();
        if (groundStateMachine.Ground.isFalling)
        {
            groundStateMachine.ChangeState(groundStateMachine.FallState);
        }
    }

    public void CountFiveSeconds()
    {
        if (countStart)
        {
            countStart = false;
            float timeCheck = 0f;
            timeCheck += Time.deltaTime;

            if (timeCheck > 5f)
            {
                groundStateMachine.ChangeState(groundStateMachine.FallState);
            }
        }
    }
}
