using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CleaningGameOverUI : MonoBehaviour
{
    [SerializeField] private Button confirmBtn;
    [SerializeField] private TMP_Text scoreTxt;
    private void Start()
    {
        confirmBtn.onClick.AddListener(LoadMainScene);
    }

    private void LoadMainScene()
    {
        //SceneManager.LoadScene("MainScene"); 
        Debug.Log("MainScene"); 
    }

    public void GameOver(int currentScore)
    {
        scoreTxt.text = currentScore.ToString();
        Time.timeScale = 0.0f;
    }
}
