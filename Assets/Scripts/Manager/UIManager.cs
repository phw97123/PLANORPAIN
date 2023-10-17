using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    Dictionary<string, UIBase> uiDic = new Dictionary<string, UIBase>();

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

    public void RemoveUIComponent<T>() where T : UIBase
    {
        string key = typeof(T).Name;
        if (uiDic.ContainsKey(key))
        {
            uiDic.Remove(key);
        }
    }
}
