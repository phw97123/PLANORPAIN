using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum PopupButtonType
{
    CONFIRM,
    CANCEL,
}

public class UI_Popup : UIBase
{
    public delegate void Callback();
    private Callback callbackConfirm;
    private Callback callbackCancel;

    [SerializeField] private TMP_Text _contentText;
    [SerializeField] private Button _confirmButton;
    [SerializeField] private Button _cancelButton;

    private TMP_Text _confirmButtonText;
    private TMP_Text _cancelButtonText;

    private void Awake()
    {
        _confirmButton.onClick.AddListener(() => ClosePopup(PopupButtonType.CONFIRM));
        _cancelButton.onClick.AddListener(() => ClosePopup(PopupButtonType.CANCEL));
        _confirmButtonText = _confirmButton.GetComponentInChildren<TMP_Text>();
        _cancelButtonText = _cancelButton.GetComponentInChildren<TMP_Text>();
        CloseUI();
    }

    public void ShowPopup(string content, string confirmButtonText, string cancelButtonText, Callback ConfirmAction, Callback CancelAction)
    {
        _contentText.text = content;
        _confirmButtonText.text = confirmButtonText;
        _cancelButtonText.text = cancelButtonText;
        callbackConfirm = ConfirmAction;
        callbackCancel = CancelAction;
        OpenUI();
    }

    public void ClosePopup(PopupButtonType buttonType)
    {
        if (buttonType == PopupButtonType.CONFIRM) callbackConfirm?.Invoke();
        else callbackCancel?.Invoke();
        CloseUI();
    }
}
