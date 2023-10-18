using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : BaseScene
{
    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.MainScene;
        UIManager.Instance.GetUIComponent<UI_MainScene>();
        SoundManager.Instance.Play("MainSceneBGM");
        return true;
    }

    public override void Clear()
    {
        UIManager.Instance.RemoveUIComponent<UI_MainScene>();
        UIManager.Instance.RemoveUIComponent<UI_Planner>();
    }
}
