using UnityEngine;
using UnityEngine.UI;

public class UI_StartScene : UIBase
{
    [SerializeField] private Button _startButton;

    private void Awake()
    {
        _startButton.onClick.AddListener(LoadMainScene);
    }

    public void LoadMainScene()
    {
        SceneManagerEx.Instance.LoadScene(Scenes.MainScene);
    }
}
