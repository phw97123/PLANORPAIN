public class CleaningGameScene : BaseScene
{
    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.CleaningGameScene;

        SoundManager.Instance.Play("CleaningGameScene/CleaningGameBGM", AudioType.BGM);
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
