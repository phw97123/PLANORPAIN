using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class CleanGameManager : MonoBehaviour
{
    public static CleanGameManager Instance;

    private float _time = 60;
    private int _score = 0;

    public float TimeRemaining => _time;
    public int CurrentScore => _score;

    [SerializeField] private CleanLogicUI logicUI;

    [SerializeField] private PlayerInput playerInput; 

    private void Awake()
    {
        Instance = this;
     
    }

    private void Start()
    {
       // playerInput.OnDisable();
    }

    private void Update()
    {
        if (TimeRemaining > 0)
            _time -= Time.deltaTime;

        logicUI.UpdateTimer(TimeRemaining);
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
