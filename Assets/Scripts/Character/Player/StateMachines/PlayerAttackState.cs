
public class PlayerAttackState : PlayerBaseState
{
    public readonly AttackInfoData AttackInfoData;
    public PlayerAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }
   
    public override void Enter()
    {
        playerStateMachine.MovementSpeedModifier = 0;
        base.Enter();

        StartAnimation(playerStateMachine.Player.AnimationData.AttackParameterHash);
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(playerStateMachine.Player.AnimationData.AttackParameterHash);
    }
}