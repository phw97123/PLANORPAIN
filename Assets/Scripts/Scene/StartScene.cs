using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : BaseScene
{
    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.StartScene;
        UIManager.Instance.GetUIComponent<UI_StartScene>();

        return true;
    }

    public override void Clear()
    {
        UIManager.Instance.RemoveUIComponent<UI_StartScene>();
    }
}
