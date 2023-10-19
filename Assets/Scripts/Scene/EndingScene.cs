using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScene : BaseScene
{
    private UIManager _uIManager;
    private void Awake()
    {
        _uIManager = UIManager.Instance;
    }
    protected override bool Init()
    {
        if (!base.Init()) return false;

        SceneType = Scenes.EndingScene;

        return true;
    }
}
