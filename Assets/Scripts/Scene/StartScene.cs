public class StartScene : BaseScene
{
    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.StartScene;

        return true;
    }
}
