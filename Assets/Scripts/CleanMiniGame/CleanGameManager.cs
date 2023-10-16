using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Events;

public enum CleanGameState
{
    NotStarted, InProgress, GameOver
}


public class CleanGameManager : MonoBehaviour
{
    public static CleanGameManager Instance;

    //UI매니저 생기면 리팩토링 예정
    [SerializeField] private CleanGameStartUI startUI;
    [SerializeField] private CleanGameLogicUI logicUI;
    [SerializeField] private CleanGameOverPanelUI gameOverPanelUI;

    [SerializeField] private PlayerInput playerInput;

    private CleanGameState _gameState; 

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
        // playerInput.OnDisable();
        startUI.OnStartBttonClicked += HandleStartButtonClicked;
    }

    private void Update()
    {
        switch(_gameState)
        {
            case CleanGameState.InProgress:
                UpdateGameInProgress();
                break;
            case CleanGameState.GameOver:
                HandleGameOver();
                break;
            default:
                break;
        }
    }

    private void HandleGameOver()
    {
        gameOverPanelUI.GameOver(CurrentScore);
    }

    private void HandleStartButtonClicked()
    {
        InitStartGame();
        SetGameState(CleanGameState.InProgress);
    }

    private void UpdateGameInProgress()
    {
        if (TimeRemaining > 0)
            _time -= Time.deltaTime;
        else
        {
            _time = 0;
            SetGameState(CleanGameState.GameOver); 
        }
        logicUI.UpdateTimer(TimeRemaining);
    }

    private void SetGameState(CleanGameState newState)
    {
        _gameState = newState;

        switch(_gameState)
        {
            case CleanGameState.NotStarted:
                break;
            case CleanGameState.InProgress:
                logicUI.gameObject.SetActive(true);
                startUI.gameObject.SetActive(false);
                break;
            case CleanGameState.GameOver:
                logicUI.gameObject.SetActive(false);
                gameOverPanelUI.gameObject.SetActive(true);
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

    public void IncreaseScore()
    {
        _score++;
        logicUI.UpdateScore(CurrentScore);
    }
}
