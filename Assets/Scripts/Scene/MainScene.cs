using UnityEngine;

public class MainScene : BaseScene
{
    private Player _player;
    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.MainScene;

        Time.timeScale = 1f;
        UIManager.Instance.GetUIComponent<UI_MainScene>();
        SoundManager.Instance.Play("MainScene/MainSceneBGM", AudioType.BGM);

        _player = GameObject.FindWithTag(Tags.PLAYER).GetComponent<Player>();
        _player.EnableActions(InputActions.Movement);

        return true;
    }

    public override void Clear()
    {
        UIManager.Instance.RemoveUIComponent<UI_MainScene>();
        UIManager.Instance.RemoveUIComponent<UI_Planner>();
    }
}
