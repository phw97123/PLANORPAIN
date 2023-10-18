using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlannerGameSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _startButton;
    public Image GameImage;
    public Image[] StarImage;
    public bool IsDestoryed = true;

    private GameManager _gameManager;
    private RectTransform _rectTransform;
    private GameObject _curSlotGame;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        _exitButton.onClick.AddListener(() => { OnClickExitButton(); });
        _startButton.onClick.AddListener(() => { OnClickStartButton(); });
        _exitButton.gameObject.SetActive(false);
        _startButton.gameObject.SetActive(false);
        foreach(var starImg in StarImage) 
        {
            starImg.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (IsDestoryed) Destroy(gameObject);
        else IsDestoryed = true;
    }

    private void OnClickExitButton()
    {
        _gameManager.CurGame = Scenes.Unknown;
        GoStartPointPrevSlot();

        _exitButton.gameObject.SetActive(false);
        _startButton.gameObject.SetActive(false);
    }

    private void OnClickStartButton()
    {
        if(_gameManager.CurGame != Scenes.Unknown)
        {
            _gameManager.LoadGameScene();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            GoStartPointPrevSlot();

            _curSlotGame = eventData.pointerDrag;
            _curSlotGame.GetComponent<RectTransform>().anchoredPosition = _rectTransform.anchoredPosition;
            _curSlotGame.GetComponent<PlannerGameIcon>().setSlot = true;
            _gameManager.CurGame = _curSlotGame.GetComponent<PlannerGameIcon>().GameScene;

            _exitButton.gameObject.SetActive(true);
            _startButton.gameObject.SetActive(true);
        }
    }

    private void GoStartPointPrevSlot()
    {
        if (_curSlotGame != null)
        {
            PlannerGameIcon prev = _curSlotGame.GetComponent<PlannerGameIcon>();
            prev.GoStartPosition();
            prev.setSlot = false;
            prev.GetComponent<Image>().raycastTarget = true;
        }
    }

}
