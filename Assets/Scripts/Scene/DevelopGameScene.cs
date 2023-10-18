using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevelopGameScene : BaseScene
{
    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.DevelopGameScene;

        // �����ϱ� �̴� ���� ���� �� �̴� ������ �Ŵ����� GameManager�κ��� ȣ�� (������ ������)
        GameManager.Instance.GetMiniGameManager<DevelopGameManager>();

        return true;
    }

    public override void Clear()
    {
        GameManager.Instance.RemoveMiniGameManager<DevelopGameManager>();

        UIManager.Instance.RemoveUIComponent<UI_DevelopGameScene>();
        UIManager.Instance.RemoveUIComponent<UI_Popup>();
        UIManager.Instance.RemoveUIComponent<UI_GameEndPopup>();
    }
}
