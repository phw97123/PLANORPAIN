using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Pos Rot Variable")]
public class PosAndRotVariable : ScriptableObject
{
    public Vector3 posValue;
    public Quaternion rotValue;
}
