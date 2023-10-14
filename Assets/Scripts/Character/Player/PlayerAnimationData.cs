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

    public int GroundParameterHash {  get; private set; }
    public int IdleParameterHash { get; private set; }
    public int WalkParameterHash { get; private set; } 

    public void Initialize()
    {
        GroundParameterHash = Animator.StringToHash(groundParameterName); 
        IdleParameterHash = Animator.StringToHash(IdleParameterName);
        WalkParameterHash = Animator.StringToHash(WalkParameterName);
    }
}
