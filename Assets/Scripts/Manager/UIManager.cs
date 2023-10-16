using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    Dictionary<string, UIBase> uiDic = new Dictionary<string, UIBase>();

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public T GetUIComponent<T>() where T : UIBase
    {
        string key = typeof(T).Name;
        if (!uiDic.ContainsKey(key))
        {
            var obj = Instantiate(Resources.Load($"Prefabs/UI/{key}"));
            uiDic.Add(key, obj.GetComponent<T>());
        }
        return (T)uiDic[key];
    }

    public void RemoveUIComponent<T>(T uiComponent) where T : UIBase
    {
        string key = typeof(T).Name;
        if (uiDic.ContainsKey(key))
        {
            uiDic.Remove(key);
        }
    }
}
