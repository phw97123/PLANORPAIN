using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_LoadingScene : UIBase
{
    [SerializeField] private Image _progressBarImage;

    private Scenes _nextSceneType = Scenes.Unknown;

    private void Start()
    {
        _nextSceneType = SceneManagerEx.Instance.NextSceneType;
        if (_nextSceneType != Scenes.Unknown) StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManagerEx.Instance.LoadSceneAsync(_nextSceneType);
        op.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                _progressBarImage.fillAmount = op.progress;
            } else
            {
                timer += Time.unscaledDeltaTime;
                _progressBarImage.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if (_progressBarImage.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
