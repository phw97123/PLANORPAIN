using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerInputActionsTest InputActions { get; private set; } 
    public PlayerInputActionsTest.PlayerActions PlayerActions { get; private set; } 

    private void Awake()
    {
        InputActions = new PlayerInputActionsTest();
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
