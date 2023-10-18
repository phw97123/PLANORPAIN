using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningGameScene : BaseScene
{
    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.CleaningGameScene;

        // 개발하기 미니 게임 시작 시 미니 게임의 매니저를 GameManager로부터 호출 (프리팹 생성됨)
        GameManager.Instance.GetMiniGameManager<CleaningGameManager>();

        return true;
    }

    public override void Clear()
    {
        GameManager.Instance.RemoveMiniGameManager<CleaningGameManager>();

        UIManager.Instance.RemoveUIComponent<CleaningGameSceneUI>();
        UIManager.Instance.RemoveUIComponent<UI_Popup>();
        UIManager.Instance.RemoveUIComponent<UI_GameEndPopup>();
    }
}
