using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx : Singleton<SceneManagerEx>
{
    private Scenes _curSceneType = Scenes.Unknown;  // ���� Scene
    private Scenes _nextSceneType = Scenes.Unknown; // ���� Scene�� LoadingScene�� ��� ������ ȣ�� �� Scene

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

    // ���� Scene ����
    public BaseScene CurrentScene
    {
        get
        {
            return GameObject.Find("@Scene").GetComponent<BaseScene>();
        }
    }

    // Scene ��ȯ
    // LoadingScene���� ��ȯ �� ���Ŀ� ���� Scene�� �Բ� ����
    // Global/Scenes �ȿ� �ҷ��� Scene Ÿ���� �����ؾ� ȣ�� ����
    // ���� : SceneManagerEx.Instance.LoadScene(Scenes.MainScene);
    public void LoadScene(Scenes sceneType, Scenes nextSceneType = Scenes.Unknown)
    {
        CurrentScene.Clear();

        _curSceneType = sceneType;
        if (_curSceneType == Scenes.LoadingScene) _nextSceneType = nextSceneType;
        SceneManager.LoadScene(_curSceneType.ToString());
    }

    // UI_LoadingScene���� ȣ��Ǵ� �Լ�
    public AsyncOperation LoadSceneAsync(Scenes sceneType)
    {
        CurrentScene.Clear();

        _curSceneType = sceneType;
        return SceneManager.LoadSceneAsync(_curSceneType.ToString());
    }
}
