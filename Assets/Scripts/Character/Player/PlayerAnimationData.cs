using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string groundParameterName = "@Ground";
    [SerializeField] private string IdleParameterName = "Idle";
    [SerializeField] private string WalkParameterName = "Walk";
    [SerializeField] private string RunParameterName = "Run";
    [SerializeField] private string AtttackParameterName = "Attack";

    public int GroundParameterHash {  get; private set; }
    public int IdleParameterHash { get; private set; }
    public int WalkParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }
    public int AttackParameterHash { get; private set; }

    public void Initialize()
    {
        GroundParameterHash = Animator.StringToHash(groundParameterName); 
        IdleParameterHash = Animator.StringToHash(IdleParameterName);
        WalkParameterHash = Animator.StringToHash(WalkParameterName);
        RunParameterHash = Animator.StringToHash(RunParameterName);
        AttackParameterHash = Animator.StringToHash(AtttackParameterName);
    }
}
