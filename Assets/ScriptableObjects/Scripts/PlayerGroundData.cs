using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerGroundData
{
    [field: SerializeField] public float BaseSpeed { get; private set; } = 5f;
    [field: SerializeField] public float BaseRotationDamping { get; private set; } = 8f;

    [field: Header("WalkData")]
    [field: SerializeField] public float WalkSpeedModifier { get; private set; } = 1f;
}
