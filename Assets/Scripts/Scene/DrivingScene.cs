using UnityEngine;

public class DrivingScene : BaseScene
{
    private UIManager _uIManager;
    private void Awake()
    {
        _uIManager = UIManager.Instance;
    }

    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.DrivingScene;

        GameManager.Instance.GetMiniGameManager<OutdoorGameManager>();
        SoundManager.Instance.Play("OutdoorGame/Paradise-Hope", AudioType.BGM);
        
        Cursor.lockState = CursorLockMode.Locked;

        return true;
    }

    public override void Clear()
    {
        Cursor.lockState = CursorLockMode.None;

        GameManager.Instance.RemoveMiniGameManager<OutdoorGameManager>();
    }
}
