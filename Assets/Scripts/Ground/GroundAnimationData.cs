using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAnimationData : MonoBehaviour
{
    [SerializeField] private string IdleParameterName = "Idle";
    [SerializeField] private string ShiverParameterName = "Shiver";

    public int IdleParameterHash { get; private set; }
    public int ShiverParameterHash { get; private set; }

    public void Initialize()
    {
        IdleParameterHash = Animator.StringToHash(IdleParameterName);
        ShiverParameterHash = Animator.StringToHash(ShiverParameterName);
    }
}
