using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_GameEndPopup : UI_BasePopup
{
    private const string DEFAULT_CONTENT = "GAME CLEAR";
    private const int DEFAULT_FONT_SIZE = 90;

    [SerializeField] private GameObject _filledStarParent;
    [SerializeField] private Button _OkButton;

    private GameObject[] _filledStars;

    protected override void Awake()
    {
        _filledStars = new GameObject[_filledStarParent.transform.childCount];
        _OkButton.onClick.AddListener(ClosePopup);
        InitScore();
        base.Awake();
    }

    private void InitScore()
    {
        for (int i = 0; i < _filledStars.Length; i++)
        {
            _filledStars[i] = _filledStarParent.transform.GetChild(i).gameObject;
            _filledStars[i].SetActive(false);
        }
    }

    // score�� 1 ~ 3�� ��
    public void SetScore(int score)
    {
        for (int i = 0; i < score; i++)
        {
            _filledStars[i].SetActive(true);
        }
    }

    public void ShowPopup(string content = DEFAULT_CONTENT, int fontSize = DEFAULT_FONT_SIZE)
    {
        SetPopupContent(content, fontSize);
        OpenUI();
    }

    public void ClosePopup()
    {
        SceneManagerEx.Instance.LoadScene(Scenes.MainScene);
        CloseUI();
    }
}
