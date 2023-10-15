using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    Punch,
    Sword,
    Gun,
}

[Serializable]

public class AttackInfoData
{
    [field: SerializeField] public string AttackName { get; private set; }
    [field: SerializeField] public int ComboStateIndex { get; private set; }
    [field: SerializeField][field: Range(0f, 1f)] public float ComboTransitionTime { get; private set; }
    [field: SerializeField][field: Range(0f, 3f)] public float ForceTransitionTime { get; private set; }
    [field: SerializeField][field: Range(-10f, 10f)] public float Force { get; private set; }

    [field: SerializeField] public int Damage { get; private set; }
}

[Serializable]
public class AttackTypes
{
    [field: SerializeField] public int AttackTypeIndex { get; private set; } // Enum.GetName(typeof(AttackType), AttackTypeIndex) È°¿ë?
    [field: SerializeField] public List<AttackInfoData> AttackInfoList { get; private set; }
}

[Serializable]
public class PlayerAttackData
{
    public List<AttackTypes> AttackInfoDatas;
    public int GetAttackInfoCount() { return AttackInfoDatas.Count; }
    public AttackInfoData GetAttackInfo(int attackType, int index)
    {
        return AttackInfoDatas[attackType].AttackInfoList[index];
    }
}