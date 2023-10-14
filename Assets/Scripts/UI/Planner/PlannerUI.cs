using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlannerUI : MonoBehaviour
{
    [SerializeField] private Image[] grayMasks; //꼭 월~금 순서대로 넣기
    [SerializeField] private RectTransform backGround;
    [SerializeField] private RectTransform gameIconPosition;
    private GameProgressManager _gameProgressManager;
    private RectTransform[] _gameIcons;

    private void Awake()
    {
        _gameProgressManager = GameProgressManager.Instance;
    }
    private void Start()
    {
        PlannerUIUpdate();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += LoadPlannerScene;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= LoadPlannerScene;
    }

    private void LoadPlannerScene(Scene scene, LoadSceneMode mode)
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
        for(int i = 0;i<= (int)_gameProgressManager.CurDay; i++)
        {
            grayMasks[i].color = newColor;
        }
    }

    private void LoadGameSlots() //리팩토링하기
    {

        Image curDayMask = grayMasks[(int)_gameProgressManager.CurDay];
        GameObject curSlot = Instantiate(Resources.Load<GameObject>($"Prefabs/Planner/PlannerGameSlot"));
        curSlot.transform.SetParent(backGround.transform);
        curSlot.GetComponent<RectTransform>().anchoredPosition = curDayMask.GetComponent<RectTransform>().anchoredPosition;

        int dayIndex = 0;
        foreach (var gamePair in _gameProgressManager.UsingGames)
        {
            curDayMask = grayMasks[dayIndex];
            curSlot = Instantiate(Resources.Load<GameObject>($"Prefabs/Planner/PlannerGameSlot"));
            curSlot.transform.SetParent(backGround.transform);
            curSlot.GetComponent<RectTransform>().anchoredPosition = curDayMask.GetComponent<RectTransform>().anchoredPosition;

            PlannerGameSlot slot = curSlot.GetComponent<PlannerGameSlot>();
            slot.GameImage.sprite = Resources.Load<Sprite>(gamePair.Value);
            slot.enabled = false;
            for(int i = 0; i < 3; i++)
            {
                slot.StarImage[i].gameObject.SetActive(true);
                if(i<_gameProgressManager.GameStars[dayIndex]) slot.StarImage[i].sprite = Resources.Load<Sprite>("Sprites/Planner/filledStar");
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
        _gameIcons = new RectTransform[_gameProgressManager.RemainingGames.Count];
        int index = 0;
        foreach (var gamePair in _gameProgressManager.RemainingGames)
        {
            _gameIcons[index] = Instantiate(Resources.Load<GameObject>($"Prefabs/Planner/PlannerGameIcon")).GetComponent<RectTransform>();
            _gameIcons[index].transform.SetParent(backGround.transform);
            PlannerGameIcon plannerGameIcon = _gameIcons[index].gameObject.GetComponent<PlannerGameIcon>();
            plannerGameIcon.GameIcon.sprite = Resources.Load<Sprite>(gamePair.Value);
            plannerGameIcon.GameScene = gamePair.Key;
            plannerGameIcon.StartPosition = gameIconPosition.anchoredPosition + new Vector2(1.4f * index * (_gameIcons[index].sizeDelta.x), 0);
            plannerGameIcon.GoStartPosition();
            index++;
        }
    }
}
