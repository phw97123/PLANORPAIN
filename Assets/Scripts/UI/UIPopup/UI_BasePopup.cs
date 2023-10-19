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

    // 팝업의 크기 및 텍스트 위치 조절
    protected void SetPopupAttributesSize(Vector2 backgroundImageSize, Vector2 textAreaSize, Vector3 textAreaTransform)
    {
        _popupBackgroundImage.rectTransform.sizeDelta = backgroundImageSize;
        _contentText.rectTransform.sizeDelta = textAreaSize;
        _contentText.rectTransform.anchoredPosition = textAreaTransform;
    }

    // 팝업 내용 텍스트 및 폰트 사이즈 조절
    protected void SetPopupContent(string content, int fontSize)
    {
        _contentText.text = content;
        _contentText.fontSize = fontSize;
    }
}
