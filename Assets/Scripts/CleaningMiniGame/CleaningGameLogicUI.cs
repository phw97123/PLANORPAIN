using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class CleaningGameLogicUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timerTxt;
    [SerializeField] private TMP_Text scoreTxt;

    private void Start()
    {
    }

    public void UpdateTimer(float time)
    {
        timerTxt.text = Mathf.Ceil(time).ToString();
    }

    public void UpdateScore(int score)
    {
        scoreTxt.text = "Score" + score;
    }
}
