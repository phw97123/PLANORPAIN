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

    private GameProgressManager _progressManager;
    private RectTransform _rectTransform;
    private GameObject _curSlotGame;

    private void Awake()
    {
        _progressManager = GameProgressManager.Instance;
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
        Destroy(gameObject);
    }

    private void OnClickExitButton()
    {
        _progressManager.CurGame = GameScene.Null;
        GoStartPointPrevSlot();

        _exitButton.gameObject.SetActive(false);
        _startButton.gameObject.SetActive(false);
    }

    private void OnClickStartButton()
    {
        if(_progressManager.CurGame != GameScene.Null)
        {
            _progressManager.LoadGameScene();
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
            _progressManager.CurGame = _curSlotGame.GetComponent<PlannerGameIcon>().GameScene;

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
