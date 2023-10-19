public class DodgeGameScene : BaseScene
{
    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.DevelopGameScene;

        // �����ϱ� �̴� ���� ���� �� �̴� ������ �Ŵ����� GameManager�κ��� ȣ�� (������ ������)
        GameManager.Instance.GetMiniGameManager<DodgeGameManager>();

        return true;
    }

    public override void Clear()
    {
        GameManager.Instance.RemoveMiniGameManager<DodgeGameManager>();

        UIManager.Instance.RemoveUIComponent<UI_DodgeGameScene>();
        UIManager.Instance.RemoveUIComponent<UI_Popup>();
        UIManager.Instance.RemoveUIComponent<UI_GameEndPopup>();
    }
}
