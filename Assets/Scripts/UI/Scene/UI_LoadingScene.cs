using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_LoadingScene : UIBase
{
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Image _progressBarImage;

    private Scenes _nextSceneType = Scenes.Unknown;

    private void Start()
    {
        _nextSceneType = SceneManagerEx.Instance.NextSceneType;
        SetBackgroundImage();
        if (_nextSceneType != Scenes.Unknown) StartCoroutine(LoadSceneProcess());
    }

    // Next Scene에 따라 로딩 이미지 변경
    private void SetBackgroundImage()
    {
        switch (_nextSceneType)
        {
            case Scenes.CleaningGameScene:
                _backgroundImage.sprite = ResourceManager.Instance.LoadSprite(Strings.Sprites.LOADING_CLEANING_IMAGE);
                break;
            case Scenes.ConvenienceStoreScene:
                _backgroundImage.sprite = ResourceManager.Instance.LoadSprite(Strings.Sprites.LOADING_WORKING_IMAGE);
                break;
            case Scenes.DevelopGameScene:
                _backgroundImage.sprite = ResourceManager.Instance.LoadSprite(Strings.Sprites.LOADING_DEVELOP_IMAGE);
                break;
            case Scenes.DodgeGameScene:
                _backgroundImage.sprite = ResourceManager.Instance.LoadSprite(Strings.Sprites.LOADING_PLAY_IMAGE);
                break;
            case Scenes.DrivingScene:
                _backgroundImage.sprite = ResourceManager.Instance.LoadSprite(Strings.Sprites.LOADING_OUTING_IMAGE);
                break;
        }
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManagerEx.Instance.LoadSceneAsync(_nextSceneType);
        op.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone)
        {
            timer += Time.unscaledDeltaTime;

            _progressBarImage.fillAmount = timer / 3f;

            if (timer > 3f)
            {
                op.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
