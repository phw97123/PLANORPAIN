using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningGameScene : BaseScene
{
    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.CleaningGameScene;

        // �����ϱ� �̴� ���� ���� �� �̴� ������ �Ŵ����� GameManager�κ��� ȣ�� (������ ������)
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
