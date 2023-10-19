using TMPro;
using UnityEngine;

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
