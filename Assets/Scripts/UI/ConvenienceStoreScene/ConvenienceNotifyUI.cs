using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvenienceNotifyUI : MonoBehaviour
{
    [SerializeField] private Button closeButton;

    void Start()
    {
        gameObject.SetActive(true);
        closeButton.onClick.AddListener(() => { OnClickExitButton(); });
        Time.timeScale = 0.0f;
    }

    private void OnClickExitButton()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

}
