using UnityEngine;
public class StartScene : BaseScene
{
    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.StartScene;

        Screen.SetResolution(1920, 1080, true);

        return true;
    }
}
