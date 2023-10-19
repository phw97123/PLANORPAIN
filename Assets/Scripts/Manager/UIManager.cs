using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    // Resources/Prefabs/UI 안의 UI 컴포넌트 프리팹들을 저장하는 딕셔너리
    Dictionary<string, UIBase> uiDic = new Dictionary<string, UIBase>();

    public T GetUIComponent<T>() where T : UIBase
    {
        string key = typeof(T).Name;
        if (!uiDic.ContainsKey(key))
        {
            // 요청 시점에 해당 UI 컴포넌트가 없다면 Load
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
