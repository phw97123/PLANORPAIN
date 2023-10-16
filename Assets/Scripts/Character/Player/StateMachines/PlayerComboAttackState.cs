using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComboAttackState : PlayerAttackState
{
    private bool alreadyAppliedForce;
    private bool alreadyApplyCombo;

    AttackInfoData attackInfoData;

    public PlayerComboAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(playerStateMachine.Player.AnimationData.ComboAttackParameterHash);

        alreadyApplyCombo = false;
        alreadyAppliedForce = false;

        int comboIndex = playerStateMachine.ComboIndex;
        int attackTypeIndex = playerStateMachine.AttackTypeIndex;
        attackInfoData = playerStateMachine.Player.Data.AttackData.GetAttackInfo(attackTypeIndex, comboIndex);
        playerStateMachine.Player.Animator.SetInteger("Combo", comboIndex);
        playerStateMachine.Player.Animator.SetInteger("AttackType", attackTypeIndex);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(playerStateMachine.Player.AnimationData.ComboAttackParameterHash);

        if (!alreadyApplyCombo)
            playerStateMachine.ComboIndex = 0;
    }

    private void TryComboAttack()
    {
        if (alreadyApplyCombo) return;

        if (attackInfoData.ComboStateIndex == -1) return;

        if (!playerStateMachine.IsAttacking) return;

        alreadyApplyCombo = true;
    }

    private void TryApplyForce()
    {
        if (alreadyAppliedForce) return;
        alreadyAppliedForce = true;

        playerStateMachine.Player.Rigidbody.AddForce(playerStateMachine.Player.transform.forward * attackInfoData.Force);
    }

    public override void Update()
    {
        base.Update();

        //ForceMove();

        float normalizedTime = GetNormalizedTime(playerStateMachine.Player.Animator, "Attack");
        if (normalizedTime < 1f)
        {
            if (normalizedTime >= attackInfoData.ForceTransitionTime)
                TryApplyForce();

            if (normalizedTime >= attackInfoData.ComboTransitionTime)
                TryComboAttack();
        }
        else
        {
            if (alreadyApplyCombo)
            {
                playerStateMachine.ComboIndex = attackInfoData.ComboStateIndex;
                playerStateMachine.ChangeState(playerStateMachine.ComboAttackState);
            }
            else
            {
                playerStateMachine.ChangeState(playerStateMachine.IdleState);
            }
        }
    }
}