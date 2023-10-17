using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx : Singleton<SceneManagerEx>
{
    private Scenes _curSceneType = Scenes.Unknown;
    private Scenes _nextSceneType = Scenes.Unknown;

    public Scenes CurrentSceneType
    {
        get
        {
            if (_curSceneType != Scenes.Unknown) return _curSceneType;
            return CurrentScene.SceneType;
        }
        set
        {
            _curSceneType = value;
        }
    }

    public Scenes NextSceneType
    {
        get
        {
            return _nextSceneType;
        }
        set
        {
            _nextSceneType = value;
        }
    }

    public BaseScene CurrentScene
    {
        get
        {
            return GameObject.Find("@Scene").GetComponent<BaseScene>();
        }
    }

    public void LoadScene(Scenes sceneType, Scenes nextSceneType = Scenes.Unknown)
    {
        CurrentScene.Clear();

        _curSceneType = sceneType;
        if (_curSceneType == Scenes.LoadingScene) _nextSceneType = nextSceneType;
        SceneManager.LoadScene(_curSceneType.ToString());
    }

    public AsyncOperation LoadSceneAsync(Scenes sceneType)
    {
        CurrentScene.Clear();

        _curSceneType = sceneType;
        return SceneManager.LoadSceneAsync(_curSceneType.ToString());
    }
}
