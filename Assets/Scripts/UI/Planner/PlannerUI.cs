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

    // Update is called once per frame
    void Update()
    {
        
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
        Image curDayMask = grayMasks[(int)_gameProgressManager.CurDay];
        Color newColor = Color.white;
        newColor.a = 0;
        curDayMask.color = newColor;

        GameObject curSlot = Instantiate(Resources.Load<GameObject>($"Prefabs/Planner/PlannerGameSlot"));
        curSlot.transform.SetParent(backGround.transform);
        curSlot.GetComponent<RectTransform>().anchoredPosition = curDayMask.GetComponent<RectTransform>().anchoredPosition;

        LoadGameIcons();



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
            plannerGameIcon.StartPosition = gameIconPosition.anchoredPosition + new Vector2(1.8f * index * (_gameIcons[index].sizeDelta.x), 0);
            plannerGameIcon.GoStartPosition();
            index++;
        }
    }
}
