public class ConvenienceStoreScene : BaseScene
{
    private UIManager _uIManager;
    private void Awake()
    {
        _uIManager = UIManager.Instance;
    }

    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.ConvenienceStoreScene;

        GameManager.Instance.GetMiniGameManager<ConvenienceStoreGameManager>();
        SoundManager.Instance.Play("ConvenienceStoreScene/ConvenienceBGM", AudioType.BGM);

        return true;
    }

    public override void Clear()
    {
        _uIManager.RemoveUIComponent<ConvenienceNotifyUI>();
        _uIManager.RemoveUIComponent<ConvenienceUI>();
        _uIManager.RemoveUIComponent<UI_GameEndPopup>();
        _uIManager.RemoveUIComponent<UI_Popup>();

    }
}
