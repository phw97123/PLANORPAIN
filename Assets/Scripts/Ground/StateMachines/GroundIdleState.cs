public class GroundIdleState : GroundBaseState
{
    public GroundIdleState(GroundStateMachine groundStateMachine) : base(groundStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //StartAnimation(groundStateMachine.Ground.AnimationData.IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(groundStateMachine.Ground.AnimationData.IdleParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (groundStateMachine.IsShivering)
        {
            OnShiver();
        }
    }
}
