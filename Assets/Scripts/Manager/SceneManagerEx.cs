using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx : Singleton<SceneManagerEx>
{
    private Scenes _curSceneType = Scenes.Unknown;  // 현재 Scene
    private Scenes _nextSceneType = Scenes.Unknown; // 현재 Scene이 LoadingScene일 경우 다음에 호출 될 Scene

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

    // 현재 Scene 정보
    public BaseScene CurrentScene
    {
        get
        {
            return GameObject.Find("@Scene").GetComponent<BaseScene>();
        }
    }

    // Scene 전환
    // LoadingScene으로 전환 시 이후에 나올 Scene도 함께 전달
    // Global/Scenes 안에 불러올 Scene 타입을 정의해야 호출 가능
    // 예시 : SceneManagerEx.Instance.LoadScene(Scenes.MainScene);
    public void LoadScene(Scenes sceneType, Scenes nextSceneType = Scenes.Unknown)
    {
        CurrentScene.Clear();

        _curSceneType = sceneType;
        if (_curSceneType == Scenes.LoadingScene) _nextSceneType = nextSceneType;
        SceneManager.LoadScene(_curSceneType.ToString());
    }

    // UI_LoadingScene에서 호출되는 함수
    public AsyncOperation LoadSceneAsync(Scenes sceneType)
    {
        CurrentScene.Clear();

        _curSceneType = sceneType;
        return SceneManager.LoadSceneAsync(_curSceneType.ToString());
    }
}
