using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_GameEndPopup : UIBase
{
    public delegate void Callback();
    private Callback callbackOk;

    [SerializeField] private GameObject _filledStarParent;
    [SerializeField] private Button _OkButton;

    private GameObject[] _filledStars;

    private void Awake()
    {
        _filledStars = new GameObject[_filledStarParent.transform.childCount];
        _OkButton.onClick.AddListener(ClosePopup);
        InitScore();
        CloseUI();
    }

    private void InitScore()
    {
        for (int i = 0; i < _filledStars.Length; i++)
        {
            _filledStars[i] = _filledStarParent.transform.GetChild(i).gameObject;
            _filledStars[i].SetActive(false);
        }
    }

    // score´Â 1 ~ 3ÀÇ °ª
    public void SetScore(int score)
    {
        for (int i = 0; i < score; i++)
        {
            _filledStars[i].SetActive(true);
        }
    }

    public void ShowPopup(Callback OkAction)
    {
        callbackOk = OkAction;
        OpenUI();
    }

    public void ClosePopup()
    {
        callbackOk?.Invoke();
        CloseUI();
    }
}
