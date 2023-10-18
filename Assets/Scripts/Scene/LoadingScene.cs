using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScene : BaseScene
{
    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.LoadingScene;
        UIManager.Instance.GetUIComponent<UI_LoadingScene>();

        return true;
    }

    public override void Clear()
    {
        UIManager.Instance.RemoveUIComponent<UI_LoadingScene>();
    }
}
