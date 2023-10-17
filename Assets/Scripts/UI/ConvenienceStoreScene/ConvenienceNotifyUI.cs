using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConvenienceNotifyUI : UIBase
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private TMP_Text notifyText;
    private int _page = 0;
    private string[] strings = 
        {
            "������ �Ƹ�����Ʈ ���� ���.. ���ڱ� �ʹ� �谡 ��������!!\r\n�׷��� ���� �մ��� ������ ���� ������ ����\r\n\r\n�ᱹ ����� ���� �ﰢ����� ������ �ϴµ� ...",
            "! ������1\r\n\r\n�մ԰� �ʹ� ����� �� �Դ´ٸ�\r\n��ġ���� �����̴� �ݹ� ��ġä�� �ҹ��� ���̴�\r\n�������� ������ ��...",
            "! ������2\r\n\r\nü���� �ʱ� ���ؼ���\r\n��� 3�� ������ �ΰ� �Ծ�� �Ѵ�",
            "! ������3\r\n\r\ncctv�� ����� ���� ���� �� �Դ´ٸ�\r\n�� ��� ���忡�� ��ȭ�� �� ���̴�",
            "W,A,S,DŰ�� �̿��� ���� ���� �� �ֽ��ϴ�\r\n\r\n�ﰢ����� ���콺�� ������ �Ծ����ϴ�"
        };

    void Start()
    {
        closeButton.onClick.AddListener(() => { OnClickExitButton(); });
        closeButton.gameObject.SetActive(false);
        nextButton.onClick.AddListener(() => { SetPopupText(strings[_page++]); });
        Time.timeScale = 0.0f;
    }

    private void OnClickExitButton()
    {
        CloseUI();
        Time.timeScale = 1.0f;
    }

    private void SetPopupText(string s)
    {
        notifyText.text = s;
        if (_page == 5) 
        { 
            closeButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(false);
        }
    }

    public void ShowPopup()
    {
        OpenUI();
        SetPopupText(strings[_page++]);
    }
}
