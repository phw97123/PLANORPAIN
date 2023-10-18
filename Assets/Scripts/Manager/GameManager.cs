using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // �� �̴� ���ӵ��� �����ϴ� �̴� ���� �Ŵ������� �����ϴ� ��ųʸ�
    private Dictionary<string, MonoBehaviour> _miniGameManagers = new Dictionary<string, MonoBehaviour>();

    // �̴� ���� �Ŵ��� ȣ�� �� ���
    // ex) GameManager.Instance.GetMiniGameManager<DevelopGameManager>();
    public T GetMiniGameManager<T>() where T : MonoBehaviour
    {
        string key = typeof(T).Name;
        if (!_miniGameManagers.ContainsKey(key))
        {
            var obj = Instantiate(Resources.Load($"Prefabs/MiniGame/{key}"));
            _miniGameManagers.Add(key, obj.GetComponent<T>());
        }
        return (T)_miniGameManagers[key];
    }

    public void RemoveMiniGameManager<T>() where T : MonoBehaviour
    {
        string key = typeof(T).Name;
        if (_miniGameManagers.ContainsKey(key))
        {
            _miniGameManagers.Remove(key);
        }
    }
}