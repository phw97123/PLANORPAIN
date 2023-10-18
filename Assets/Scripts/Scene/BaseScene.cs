using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 모든 Scene 클래스의 부모 클래스
public class BaseScene : MonoBehaviour
{
    public Scenes SceneType = Scenes.Unknown;

    protected bool _init = false;

    private void Start()
    {
        Init();
    }

    protected virtual bool Init()
    {
        if (_init) return false;

        _init = true;
        Object go = FindObjectOfType(typeof(EventSystem));
        if (go == null) Instantiate(Resources.Load("Prefabs/UI/EventSystem"));

        return true;
    }

    public virtual void Clear() { }
}
