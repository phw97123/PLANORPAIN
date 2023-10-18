using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerInputActionsTest InputActions { get; private set; } // Test 버전 적용
    public PlayerInputActionsTest.PlayerActions PlayerActions { get; private set; } // Test 버전 적용

    private void Awake()
    {
        InputActions = new PlayerInputActionsTest(); // Test 버전 적용
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
