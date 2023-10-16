using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CleanGameOverPanelUI : MonoBehaviour
{
    [SerializeField] private Button confirmBtn;
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private GameObject Panel; 

    private void Awake()
    {
       Panel.SetActive(false);
    }

    private void Start()
    {
        confirmBtn.onClick.AddListener(LoadMainScene);
        CleanGameManager.Instance.OnGameOverEvent += GameOver; 
    }

    private void LoadMainScene()
    {
        //SceneManager.LoadScene("MainScene"); 
        Debug.Log("MainScene"); 
    }

    public void GameOver(int currentScore)
    {
        Panel.SetActive(true);
        scoreTxt.text = currentScore.ToString();
        Time.timeScale = 0.0f;
    }
}
