using UnityEngine;

public class GymScene : BaseScene
{
    private UIManager _uIManager;
    private void Awake()
    {
        _uIManager = UIManager.Instance;
    }

    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.GymScene;
        SoundManager.Instance.Play("OutdoorGame/DrumsAndBass", AudioType.BGM);

        Cursor.lockState = CursorLockMode.Locked;

        return true;
    }

    public override void Clear()
    {
        Cursor.lockState = CursorLockMode.None;

        _uIManager.RemoveUIComponent<UI_GameEndPopup>();
    }
}
