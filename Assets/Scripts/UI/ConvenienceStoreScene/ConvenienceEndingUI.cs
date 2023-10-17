using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConvenienceEndingUI : UI_GameEndPopup
{
    [SerializeField] private TMP_Text gameEndingText;

    public void SetPopupText(string s)
    {
        gameEndingText.text = s;
    }
}
