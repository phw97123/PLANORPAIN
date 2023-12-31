public class DodgeGameScene : BaseScene
{
    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.DevelopGameScene;

        // 개발하기 미니 게임 시작 시 미니 게임의 매니저를 GameManager로부터 호출 (프리팹 생성됨)
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
