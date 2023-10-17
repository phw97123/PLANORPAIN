using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class CleaningGameSceneUI : UIBase
{
    [SerializeField] private TMP_Text timerTxt;
    [SerializeField] private TMP_Text scoreTxt;

    public void UpdateTimer(float time)
    {
        timerTxt.text ="TIME\n" + Mathf.Ceil(time).ToString();
    }

    public void UpdateScore(int score)
    {
        scoreTxt.text = "SCORE\n" + score;
    }
}
