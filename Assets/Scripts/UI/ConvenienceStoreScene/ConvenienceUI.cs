using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvenienceUI : UIBase
{
    [SerializeField] private Image[] stars;
    private ConvenienceStoreGameManager _convenienceStoreGame;

    private void Start()
    {
        _convenienceStoreGame = ConvenienceStoreGameManager.Instance;
        _convenienceStoreGame.ChangeScoreEvent += ChangeStarImage;
    }

    private void ChangeStarImage()
    {
        int score = _convenienceStoreGame.score;
        Color color = Color.white;
        color.a = 0;
        for (int i = 0; i < stars.Length - score; i++)
        {
            stars[i].color = color;
        }
    }
}
