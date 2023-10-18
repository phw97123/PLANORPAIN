using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvenienceStoreScene : BaseScene
{
    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.ConvenienceStoreScene;

        GameManager.Instance.GetMiniGameManager<ConvenienceStoreGameManager>();

        return true;
    }

    public override void Clear()
    {
        UIManager.Instance.RemoveUIComponent<ConvenienceNotifyUI>();
        UIManager.Instance.RemoveUIComponent<ConvenienceUI>();
        UIManager.Instance.RemoveUIComponent<UI_GameEndPopup>();
        UIManager.Instance.RemoveUIComponent<UI_Popup>();

    }
}
