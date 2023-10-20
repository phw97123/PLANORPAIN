public class DevelopGameScene : BaseScene
{
    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.DevelopGameScene;

        SoundManager.Instance.Play(Strings.Sounds.DEVELOP_GAME_BGM, AudioType.BGM);
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
