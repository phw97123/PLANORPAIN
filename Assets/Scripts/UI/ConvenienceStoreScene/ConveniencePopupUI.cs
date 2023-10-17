using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConveniencePopupUI : UIBase
{
    public TMP_Text PopupText;

    public void ShowPopup(string s)
    {
        OpenUI();
        CancelInvoke("CloseUI");
        PopupText.text = s;
        Invoke("CloseUI", 0.5f);
    }
}
