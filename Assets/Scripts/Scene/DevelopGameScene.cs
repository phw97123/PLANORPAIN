public class DevelopGameScene : BaseScene
{
    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.DevelopGameScene;

        SoundManager.Instance.Play(Strings.Sounds.DEVELOP_GAME_BGM, AudioType.BGM);
        // 개발하기 미니 게임 시작 시 미니 게임의 매니저를 GameManager로부터 호출 (프리팹 생성됨)
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
