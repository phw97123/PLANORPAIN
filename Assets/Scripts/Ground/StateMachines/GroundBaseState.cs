public class GroundBaseState : IState
{
    protected GroundStateMachine groundStateMachine;

    public GroundBaseState(GroundStateMachine groundStateMachine)
    {
        this.groundStateMachine = groundStateMachine;
    }
    public virtual void Enter()
    {

    }
    public virtual void Exit()
    {

    }
    public virtual void Update()
    {

    }
    public virtual void PhysicsUpdate()
    {

    }

    public void HandleInput()
    {
        
    }

    protected void StartAnimation(int animationHash)
    {
        groundStateMachine.Ground.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        groundStateMachine.Ground.Animator.SetBool(animationHash, false);
    }

    protected virtual void OnShiver()
    {
        groundStateMachine.ChangeState(groundStateMachine.ShiverState);
    }
}
