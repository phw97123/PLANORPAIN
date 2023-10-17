using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDevelopGameScene_kjm : BaseScene
{
    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.CreateDevelopGameScene_kjm;

        GameManager.Instance.GetMiniGameManager<DevelopGameManager>();

        return true;
    }

    public override void Clear()
    {
        GameManager.Instance.RemoveMiniGameManager<DevelopGameManager>();
    }
}
