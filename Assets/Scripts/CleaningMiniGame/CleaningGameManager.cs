using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public enum CleaningGameState
{
    NotStarted, InProgress, GameOver
}

public class CleaningGameManager : MonoBehaviour
{
    public static CleaningGameManager Instance;

    [SerializeField] private CleaningGameStartUI startUI;
    [SerializeField] private CleaningGameLogicUI logicUI;
    [SerializeField] private CleaningGameOverUI gameOverUI;

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Cat cat; 

    [SerializeField] private PlayableDirector playableDirector;

    private bool _isTimelinePlay = false;

    private CleaningGameState _gameState;

    private float _time = 60;
    private int _score = 0;

    public float TimeRemaining => _time;
    public int CurrentScore => _score;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //playerInput.OnDisable();
        SetGameState(CleaningGameState.NotStarted);
        startUI.OnStartBttonClicked += HandleStartButtonClicked;

        playableDirector.Stop();
        cat.gameObject.SetActive(false);
    }

    private void Update()
    {
        switch (_gameState)
        {
            case CleaningGameState.InProgress:
                UpdateGameInProgress();
                if (TimeRemaining <= 30f && !_isTimelinePlay)
                {
                    playableDirector.Play();
                    _isTimelinePlay = true;
                }
                break;
            case CleaningGameState.GameOver:
                HandleGameOver();
                break;
            default:
                break;
        }
    }

    public void InitStartGame()
    {
        _time = 60f;
        _score = 0;

        //playerInput.OnEnable();

        logicUI.UpdateScore(CurrentScore);
        logicUI.UpdateTimer(TimeRemaining);
    }

    private void HandleStartButtonClicked()
    {
        InitStartGame();
        SetGameState(CleaningGameState.InProgress);
    }

    private void HandleGameOver()
    {
        gameOverUI.GameOver(CurrentScore);
    }

    private void UpdateGameInProgress()
    {
        if (TimeRemaining > 0)
            _time -= Time.deltaTime;
        else
        {
            _time = 0;
            SetGameState(CleaningGameState.GameOver);
        }
        logicUI.UpdateTimer(TimeRemaining);
    }

    private void SetGameState(CleaningGameState newState)
    {
        _gameState = newState;

        switch (_gameState)
        {
            case CleaningGameState.NotStarted:
                SetActiveUI(startUI);
                break;
            case CleaningGameState.InProgress:
                SetActiveUI(logicUI);
                break;
            case CleaningGameState.GameOver:
                SetActiveUI(gameOverUI);
                break;
            default:
                break;
        }
    }

    private void SetActiveUI(MonoBehaviour activeUI)
    {
        startUI.gameObject.SetActive(activeUI == startUI);
        logicUI.gameObject.SetActive(activeUI == logicUI);
        gameOverUI.gameObject.SetActive(activeUI == gameOverUI);
    }

    public void IncreaseScore()
    {
        _score++;
        logicUI.UpdateScore(CurrentScore);
    }

    public void DecreaseScore()
    {
        _score--;
        logicUI.UpdateScore(CurrentScore);
    }
    public void ChangeScore(int amount)
    {
        _score += amount;
        logicUI.UpdateScore(CurrentScore);
    }

}
