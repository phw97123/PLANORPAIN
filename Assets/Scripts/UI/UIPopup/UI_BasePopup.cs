using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_BasePopup : UIBase
{
    [SerializeField] protected Image _popupBackgroundImage;
    [SerializeField] protected GameObject _contentTextObject;

    protected TMP_Text _contentText;

    protected virtual void Awake()
    {
        _contentText = _contentTextObject.GetComponent<TMP_Text>();
        CloseUI();
    }

    // �˾��� ũ�� �� �ؽ�Ʈ ��ġ ����
    protected void SetPopupAttributesSize(Vector2 backgroundImageSize, Vector2 textAreaSize, Vector3 textAreaTransform)
    {
        _popupBackgroundImage.rectTransform.sizeDelta = backgroundImageSize;
        _contentText.rectTransform.sizeDelta = textAreaSize;
        _contentText.rectTransform.anchoredPosition = textAreaTransform;
    }

    // �˾� ���� �ؽ�Ʈ �� ��Ʈ ������ ����
    protected void SetPopupContent(string content, int fontSize)
    {
        _contentText.text = content;
        _contentText.fontSize = fontSize;
    }
}
