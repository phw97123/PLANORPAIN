using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string groundParameterName = "@Ground";
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string walkParameterName = "Walk";
    [SerializeField] private string RunParameterName = "Run";
    [SerializeField] private string cleaningParameterName = "Cleaning";
    [SerializeField] private string AtttackParameterName = "@Attack";
    [SerializeField] private string AttackTypeParameterName = "AttackType";
    [SerializeField] private string comboAttackParameterName = "ComboAttack";

    public int GroundParameterHash { get; private set; }
    public int IdleParameterHash { get; private set; }
    public int WalkParameterHash { get; private set; }
    public int CleaningParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }
    public int AttackParameterHash { get; private set; }
    public int AttackTypeParameterHash { get; private set; }
    public int ComboAttackParameterHash { get; private set; }

    public void Initialize()
    {
        GroundParameterHash = Animator.StringToHash(groundParameterName);
        IdleParameterHash = Animator.StringToHash(idleParameterName);

        WalkParameterHash = Animator.StringToHash(walkParameterName);
        RunParameterHash = Animator.StringToHash(RunParameterName);
        CleaningParameterHash = Animator.StringToHash(cleaningParameterName);

        AttackParameterHash = Animator.StringToHash(AtttackParameterName);
        AttackTypeParameterHash = Animator.StringToHash(AttackTypeParameterName);
        ComboAttackParameterHash = Animator.StringToHash(comboAttackParameterName);
    }
}


