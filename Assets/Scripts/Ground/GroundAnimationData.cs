using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GroundAnimationData
{
    [SerializeField] private string IdleParameterName = "Idle";
    [SerializeField] private string ShiverParameterName = "Shiver";
    [SerializeField] private string FallParameterName = "Fall";

    public int IdleParameterHash { get; private set; }
    public int ShiverParameterHash { get; private set; }
    public int FallParameterHash { get; private set; }

    public void Initialize()
    {
        IdleParameterHash = Animator.StringToHash(IdleParameterName);
        ShiverParameterHash = Animator.StringToHash(ShiverParameterName);
        FallParameterHash = Animator.StringToHash(FallParameterName);
    }
}
