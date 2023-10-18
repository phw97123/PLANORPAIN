using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Planner : UIBase
{
    [SerializeField] private Image[] grayMasks; //�� ��~�� ������� �ֱ�
    [SerializeField] private RectTransform backGround;
    [SerializeField] private RectTransform gameIconPosition;
    private GameManager _gameManager;
    private RectTransform[] _gameIcons;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    private void OnEnable()
    {
        PlannerUIUpdate();
    }

    private void PlannerUIUpdate()
    {
        ChangeAlphaGrayMask();

        LoadGameSlots();

        LoadGameIcons();
    }

    private void ChangeAlphaGrayMask()
    {
        Color newColor = Color.white;
        newColor.a = 0;
        for(int i = 0;i<= (int)_gameManager.CurDay; i++)
        {
            grayMasks[i].color = newColor;
        }
    }

    private void LoadGameSlots() //�����丵�ϱ�
    {

        Image curDayMask = grayMasks[(int)_gameManager.CurDay];
        GameObject curSlot = Instantiate(Resources.Load<GameObject>($"Prefabs/UI/Planner/PlannerGameSlot"));
        curSlot.transform.SetParent(backGround.transform);
        curSlot.GetComponent<RectTransform>().anchoredPosition = curDayMask.GetComponent<RectTransform>().anchoredPosition;

        int dayIndex = 0;
        foreach (var gamePair in _gameManager.UsingGames)
        {
            curDayMask = grayMasks[dayIndex];
            curSlot = Instantiate(Resources.Load<GameObject>($"Prefabs/UI/Planner/PlannerGameSlot"));
            curSlot.transform.SetParent(backGround.transform);
            curSlot.GetComponent<RectTransform>().anchoredPosition = curDayMask.GetComponent<RectTransform>().anchoredPosition;

            PlannerGameSlot slot = curSlot.GetComponent<PlannerGameSlot>();
            slot.GameImage.sprite = ResourceManager.Instance.LoadSprite($"{gamePair.Value}Image"); 
            slot.IsDestoryed = false;
            slot.enabled = false;
            for(int i = 0; i < 3; i++)
            {
                slot.StarImage[i].gameObject.SetActive(true);
                if (i < _gameManager.GameStars[dayIndex]) slot.StarImage[i].sprite = ResourceManager.Instance.LoadSprite("Planner/filledStar");
            }

            dayIndex++;
        }
    }

    private void LoadGameIcons()
    {
        if (_gameIcons != null)
        {
            foreach (var iconrect in _gameIcons)
            {
                Destroy(iconrect.gameObject);
            }
        }
        _gameIcons = new RectTransform[_gameManager.RemainingGames.Count];
        int index = 0;
        foreach (var gamePair in _gameManager.RemainingGames)
        {
            _gameIcons[index] = Instantiate(Resources.Load<GameObject>($"Prefabs/UI/Planner/PlannerGameIcon")).GetComponent<RectTransform>();
            _gameIcons[index].transform.SetParent(backGround.transform);
            PlannerGameIcon plannerGameIcon = _gameIcons[index].gameObject.GetComponent<PlannerGameIcon>();
            plannerGameIcon.GameIcon.sprite = ResourceManager.Instance.LoadSprite(gamePair.Value);
            plannerGameIcon.GameScene = gamePair.Key;
            plannerGameIcon.StartPosition = gameIconPosition.anchoredPosition + new Vector2(1.4f * index * (_gameIcons[index].sizeDelta.x), 0);
            plannerGameIcon.GoStartPosition();
            index++;
        }
    }
}