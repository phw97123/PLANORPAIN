using System;
using UnityEngine;

[Serializable]
public class PlayerGroundData
{
    [field: SerializeField] public float BaseSpeed { get; private set; } = 5f;
    [field: SerializeField] public float BaseRotationDamping { get; private set; } = 8f;

    [field: Header("WalkData")]
    [field: SerializeField] public float WalkSpeedModifier { get; private set; } = 1f;

    [field: Header("RunData")]
    [field: SerializeField] public float RunSpeedModifier { get; private set; } = 3f;

}
