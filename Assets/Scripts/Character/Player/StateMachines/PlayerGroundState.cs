using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundState : PlayerBaseState
{
    public PlayerGroundState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(playerStateMachine.Player.AnimationData.GroundParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(playerStateMachine.Player.AnimationData.GroundParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (playerStateMachine.IsAttacking)
        {
            OnAttack();
            return;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    protected override void OnMovementCanceled(InputAction.CallbackContext context)
    {
        if (playerStateMachine.MovementInput == Vector2.zero)
            return;

        playerStateMachine.ChangeState(playerStateMachine.IdleState);

        base.OnMovementCanceled(context);
    }

    protected virtual void OnMove()
    {
        if (playerStateMachine.Player.Mop.activeSelf)
        {
            playerStateMachine.ChangeState(playerStateMachine.CleaningState);
        }
        else
        {
            playerStateMachine.ChangeState(playerStateMachine.WalkState);
        }
    }

    protected virtual void OnAttack()
    {
        playerStateMachine.ChangeState(playerStateMachine.ComboAttackState);
    }
}