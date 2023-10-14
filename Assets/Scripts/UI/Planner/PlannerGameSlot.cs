using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlannerGameSlot : MonoBehaviour, IDropHandler
{
    public Button _exitButton;
    public Button _startButton;
    public Image GameImage;

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
    }

    private void OnClickExitButton()
    {
        _progressManager.CurGame = GameScene.Null;
        if (_curSlotGame != null)
        {
            PlannerGameIcon prev = _curSlotGame.GetComponent<PlannerGameIcon>();
            prev.GoStartPosition();
            prev.setSlot = false;
        }

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


    // Update is called once per frame
    private void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            if(_curSlotGame != null)
            {
                PlannerGameIcon prev = _curSlotGame.GetComponent<PlannerGameIcon>();
                prev.GoStartPosition();
                prev.setSlot = false;
            }
            _curSlotGame = eventData.pointerDrag;
            _curSlotGame.GetComponent<RectTransform>().anchoredPosition = _rectTransform.anchoredPosition;
            _curSlotGame.GetComponent<PlannerGameIcon>().setSlot = true;
            _progressManager.CurGame = _curSlotGame.GetComponent<PlannerGameIcon>().GameScene;
            Debug.Log(_progressManager.CurGame);

            _exitButton.gameObject.SetActive(true);
            _startButton.gameObject.SetActive(true);
        }
    }
}
