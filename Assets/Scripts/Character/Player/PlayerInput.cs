using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerInputActionsTest InputActions { get; private set; } // Test ���� ����
    public PlayerInputActionsTest.PlayerActions PlayerActions { get; private set; } // Test ���� ����

    private void Awake()
    {
        InputActions = new PlayerInputActionsTest(); // Test ���� ����
        PlayerActions = InputActions.Player;

        OnEnable(); 
    }

    private void OnEnable()
    {
        InputActions.Enable();
    }

    public void OnDisable()
    {
        InputActions.Disable();
    }
}
