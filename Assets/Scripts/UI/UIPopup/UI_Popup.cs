using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Popup : MonoBehaviour
{
    public delegate void Callback();
    private Callback callbackConfirm;
    private Callback callbackCancel;

    [SerializeField] private TMP_Text _contentText;

    public void ShowPopup(string content, Callback ConfirmAction, Callback CancelAction)
    {
        _contentText.text = content;
        callbackConfirm = ConfirmAction;
        callbackCancel = CancelAction;
    }

    public void ClosePopup()
    {
        callbackConfirm?.Invoke();
        callbackCancel?.Invoke();
        gameObject.SetActive(false);
    }
}
