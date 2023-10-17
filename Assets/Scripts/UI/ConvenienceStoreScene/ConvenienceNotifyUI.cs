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
            "편의점 아르바이트 중인 당신.. 갑자기 너무 배가 고파졌다!!\r\n그러나 꼬마 손님은 도무지 나갈 생각이 없고\r\n\r\n결국 당신은 몰래 삼각김밥을 먹으려 하는데 ...",
            "! 주의점1\r\n\r\n손님과 너무 가까울 때 먹는다면\r\n눈치빠른 꼬맹이는 금방 눈치채고 소문낼 것이다\r\n나빠지는 평판은 덤...",
            "! 주의점2\r\n\r\n체하지 않기 위해서는\r\n적어도 3초 간격을 두고 먹어야 한다",
            "! 주의점3\r\n\r\ncctv가 당신을 보고 있을 때 먹는다면\r\n그 즉시 점장에게 전화가 올 것이다",
            "W,A,S,D키를 이용해 고개를 돌릴 수 있습니다\r\n\r\n삼각김밥을 마우스로 누르면 먹어집니다"
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
