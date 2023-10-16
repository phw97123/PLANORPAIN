using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI; 

public class CleanGameLogicUI : MonoBehaviour
{
    [SerializeField] private Button startBtn;
    [SerializeField] private TMP_Text timerTxt;
    [SerializeField] private TMP_Text scoreTxt;

    private CleanGameManager _cleanGameManager;

    private void Awake()
    {
    }

    private void Start()
    {
        _cleanGameManager = CleanGameManager.Instance;
        startBtn.onClick.AddListener(StartGame); 
    }

    public void UpdateTimer(float time)
    {
        timerTxt.text = Mathf.Ceil(time).ToString();
    }

    public void UpdateScore(int score)
    {
        scoreTxt.text = "Score: " + score;
    }

    public void StartGame()
    {
        _cleanGameManager.InitStartGame();
        startBtn.gameObject.SetActive(false);
        timerTxt.gameObject.SetActive(true);
        scoreTxt.gameObject.SetActive(true);
    }
}
