using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConveniencePopupUI : MonoBehaviour
{
    public TMP_Text PopupText;
    private ConvenienceStoreGame _game;

    private void Awake()
    {
        _game = ConvenienceStoreGame.Instance;
    }

    private void Start()
    {
        _game.PopupUI += SetPopupText;
        gameObject.SetActive(false);
    }

    private void SetPopupText(string s)
    {
        CancelInvoke(s);
        gameObject.SetActive(true);
        PopupText.text = s;
        Invoke("SetActiveFalse", 1.0f);
    }

    private void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
