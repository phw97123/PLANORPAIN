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
    OK,
    NOTIFY,
}

public class UI_Popup : UI_BasePopup
{
    #region const values
    // �⺻ �˾� ������
    private const int DEFAULT_POPUP_WIDTH = 800;
    private const int DEFAULT_POPUP_HEIGHT = 600;
    // �⺻ �˾� �ؽ�Ʈ ���� ������
    private const int DEFAULT_TEXT_WIDTH = 600;
    private const int DEFAULT_TEXT_HEIGHT = 240;

    // �˸� �˾� ������
    private const int NOTIFICATION_POPUP_WIDTH = 600;
    private const int NOTIFICATION_POPUP_HEIGHT = 400;
    // �˸� �˾� �ؽ�Ʈ ���� ������
    private const int NOTIFICATION_TEXT_WIDTH = 500; 
    private const int NOTIFICATION_TEXT_HEIGHT = 300;

    // �⺻ �ؽ�Ʈ ������
    private const int DEFAULT_FONT_SIZE = 45;
    #endregion

    public delegate void Callback();
    private Callback callbackConfirm;
    private Callback callbackCancel;
    private Callback callbackOk;

    [SerializeField] private GameObject _confirmButtonObject;
    [SerializeField] private GameObject _cancelButtonObject;
    [SerializeField] private GameObject _okButtonObject;

    private Button _confirmButton;
    private Button _cancelButton;
    private Button _okButton;

    private TMP_Text _confirmButtonText;
    private TMP_Text _cancelButtonText;
    private TMP_Text _okButtonText;

    protected override void Awake()
    {
        InitBind();
        base.Awake();
    }

    #region Bind Datas
    private void InitBind()
    {
        _confirmButton = _confirmButtonObject.GetComponent<Button>();
        _cancelButton = _cancelButtonObject.GetComponent<Button>();
        _okButton = _okButtonObject.GetComponent<Button>();

        _confirmButtonText = _confirmButton.GetComponentInChildren<TMP_Text>();
        _cancelButtonText = _cancelButton.GetComponentInChildren<TMP_Text>();
        _okButtonText = _okButton.GetComponentInChildren<TMP_Text>();

        _confirmButton.onClick.AddListener(() => ClosePopup(PopupButtonType.CONFIRM));
        _cancelButton.onClick.AddListener(() => ClosePopup(PopupButtonType.CANCEL));
        _okButton.onClick.AddListener(() => ClosePopup(PopupButtonType.OK));
    }
    #endregion

    private void SetButtonActive(PopupButtonType buttonType)
    {
        switch (buttonType)
        {
            case PopupButtonType.CONFIRM:
            case PopupButtonType.CANCEL:
                _confirmButtonObject.SetActive(true);
                _cancelButtonObject.SetActive(true);
                _okButtonObject.SetActive(false);
                break;
            case PopupButtonType.OK:
                _confirmButtonObject.SetActive(false);
                _cancelButtonObject.SetActive(false);
                _okButtonObject.SetActive(true);
                break;
            case PopupButtonType.NOTIFY:
                _confirmButtonObject.SetActive(false);
                _cancelButtonObject.SetActive(false);
                _okButtonObject.SetActive(false);
                break;
        }
    }

    #region ShowPopup
    // Ȯ��, ��� ��ư�� �ִ� �˾�
    public void ShowPopup(string content, string confirmButtonText, string cancelButtonText, 
        Callback ConfirmAction, Callback CancelAction, int fontSize = DEFAULT_FONT_SIZE)
    {
        SetPopupAttributes(PopupButtonType.CONFIRM);
        SetButtonActive(PopupButtonType.CONFIRM);

        SetPopupContent(content, fontSize);
        _confirmButtonText.text = confirmButtonText;
        _cancelButtonText.text = cancelButtonText;

        callbackConfirm = ConfirmAction;
        callbackCancel = CancelAction;
        OpenUI();
    }

    // Ȯ�� ��ư�� �ִ� �˾�
    public void ShowPopup(string content, string okButtonText, Callback OkAction, int fontSize = DEFAULT_FONT_SIZE)
    {
        SetPopupAttributes(PopupButtonType.OK);
        SetButtonActive(PopupButtonType.OK);

        SetPopupContent(content, fontSize);
        _okButtonText.text = okButtonText;

        callbackOk = OkAction;
        OpenUI();
    }

    // ��ư ���� �˸� �˾�
    public void ShowPopup(string content, int fontSize = DEFAULT_FONT_SIZE)
    {
        SetPopupAttributes(PopupButtonType.NOTIFY);
        SetButtonActive(PopupButtonType.NOTIFY);

        SetPopupContent(content, fontSize);

        OpenUI();
        CloseUIWithDelay();
    }
    #endregion

    public void ClosePopup(PopupButtonType buttonType)
    {
        if (buttonType == PopupButtonType.CONFIRM) callbackConfirm?.Invoke();
        else if (buttonType == PopupButtonType.CANCEL) callbackCancel?.Invoke();
        else if (buttonType == PopupButtonType.OK) callbackOk?.Invoke();
        CloseUI();
    }

    private void CloseUIWithDelay()
    {
        Invoke("CloseUI", 1f);
    }

    #region Set Popup Attributes
    // �˾��� ũ�� �� �ؽ�Ʈ ��ġ ���� (�˸� �˾��� ���� �� �� ���)
    private void SetPopupAttributes(PopupButtonType buttonType)
    {
        switch (buttonType)
        {
            case PopupButtonType.CONFIRM:
            case PopupButtonType.CANCEL:
            case PopupButtonType.OK:
                SetPopupAttributesSize(
                    new Vector2(DEFAULT_POPUP_WIDTH, DEFAULT_POPUP_HEIGHT),
                    new Vector2(DEFAULT_TEXT_WIDTH, DEFAULT_TEXT_HEIGHT),
                    new Vector3(0, 35f, 0)
                    ); 
                break;
            case PopupButtonType.NOTIFY:
                SetPopupAttributesSize(
                    new Vector2(NOTIFICATION_POPUP_WIDTH, NOTIFICATION_POPUP_HEIGHT),
                    new Vector2(NOTIFICATION_TEXT_WIDTH, NOTIFICATION_TEXT_HEIGHT),
                    new Vector3(0, -20f, 0)
                    );
                break;
        }
    }
    #endregion
}
