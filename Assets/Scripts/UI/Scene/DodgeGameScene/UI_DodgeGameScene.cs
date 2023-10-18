using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_DodgeGameScene : UIBase
{
    [Header("Score")]
    [SerializeField] private TMP_Text score;

    [Header("Timer")]
    [SerializeField] public TMP_Text timerText;
    private float currentScore;
    private float bonusScore;

    private float maxTime;

    private Player player;

    [SerializeField] private LayerMask lavaLayer;

    [Header("HpBar")]
    public Slider hpbar;
    public float maxHp;
    public float currentHp;

    private void Awake()
    {
        player = DodgeGameManager.DInstance.player.GetComponent<Player>();
        maxHp = player.Data.MaxHp;
        
        maxTime = float.Parse(timerText.text);
        hpbar = GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        currentHp = DodgeGameManager.DInstance.currentHp;
        hpbar.value = currentHp / maxHp;
        maxTime -= Time.deltaTime;
        timerText.text = maxTime.ToString("F2");

        currentScore += (10 * Time.deltaTime * (currentHp / maxHp) % 1) + bonusScore;
        score.text = ((int)currentScore).ToString();
    }

    private float CalculateScore()
    {
        bonusScore = GroundManager.GInstance.score;
        return bonusScore;
    }

    public int GetScore()
    {
        if (currentScore >= 300) return 3;
        if (currentScore >= 200) return 2;
        else return 1;
    }
}
