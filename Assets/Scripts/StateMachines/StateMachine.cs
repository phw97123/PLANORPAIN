public abstract class StateMachine
{
    protected IState CurrentState; 
    public void ChangeState(IState newState)
    {
        CurrentState?.Exit(); 
        CurrentState = newState;
        CurrentState?.Enter(); 
    }

    public void HandleInput()
    {
        CurrentState?.HandleInput(); 
    }

    public void Update()
    {
        CurrentState?.Update();
    }

    public void PhysicsUpdate()
    {
        CurrentState?.PhysicsUpdate();
    }
}
