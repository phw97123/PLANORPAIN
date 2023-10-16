using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleaningGameStartUI : MonoBehaviour
{
    public event Action OnStartBttonClicked;

    [SerializeField] Button startBtn;

    private void Start()
    {
        startBtn.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        OnStartBttonClicked?.Invoke();
        gameObject.SetActive(false);
    }
}
