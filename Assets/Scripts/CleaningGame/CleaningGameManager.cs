using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CleaningGameManager : MonoBehaviour
{
    public static CleaningGameManager Instance;

    [SerializeField] private PlayableDirector playableDirector;

    private CleaningGameSceneUI _logicUI;

    private GameObject _player;
    private GameObject _cat; 

    private UI_Popup _uiPopup;
    private UI_GameEndPopup _uiGameEndPopup;

    private bool _isTimelinePlay = false;

    private float _time = 60;
    private int _score = 0;

    public float TimeRemaining => _time;
    public int CurrentScore => _score;

    private void Awake()
    {
        Instance = this; 

        _player = GameObject.FindWithTag(Tags.PLAYER); 
        _cat = GameObject.FindWithTag(Tags.CAT);
    }

    private void Start()
    {
        _uiPopup = UIManager.Instance.GetUIComponent<UI_Popup>();
        _uiGameEndPopup = UIManager.Instance.GetUIComponent<UI_GameEndPopup>();
        _logicUI = UIManager.Instance.GetUIComponent<CleaningGameSceneUI>();
        
        _uiPopup.ShowPopup(Strings.PopupContent.CLEANING_GAME_NOTIFICATION, Strings.PopupButtons.OK, StartTimeScale);

        Time.timeScale = 0;
        playableDirector.Stop();
        _cat.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (TimeRemaining > 0)
        {
            _time -= Time.deltaTime;

            if (TimeRemaining <= 30f && !_isTimelinePlay)
            {
                playableDirector.Play();
                _isTimelinePlay = true;
            }
        }
        else
        {
            _time = 0;
            GameOver(); 
        }

        UpdateTimer(); 
    }

    private int GetScore()
    {
        if (CurrentScore <= 10) return 1;
        if (CurrentScore <= 20) return 2;
        else return 3; 
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        _uiGameEndPopup.SetScore(GetScore());
        _uiGameEndPopup.ShowPopup(() => { SceneManager.LoadScene("MainScene"); });
    }

    private void UpdateTimer()
    {
        _logicUI.UpdateTimer(TimeRemaining);
    }

    public void ChangeScore(int amount)
    {
        _score += amount;
        _logicUI.UpdateScore(CurrentScore);
    }

    private void StartTimeScale()
    {
        Time.timeScale = 1;
    }
}