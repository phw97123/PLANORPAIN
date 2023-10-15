using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerInputActionsTest InputActions { get; private set; } // Test 버전 적용
    public PlayerInputActionsTest.PlayerActions PlayerActions { get; private set; } // Test 버전 적용

    public CinemachineVirtualCamera virtualCamera;

    public float zoomSpeed = 5.0f;
    public float minFov = 20.0f;
    public float maxFov = 50.0f; 

    private void Awake()
    {
        InputActions = new PlayerInputActionsTest(); // Test 버전 적용
        PlayerActions = InputActions.Player;
    }

    private void OnEnable()
    {
        InputActions.Enable();
    }

    private void OnDisable()
    {
        InputActions.Disable();
    }

    private void Update()
    {
        float scrollInput = InputActions.Player.CameraZoom.ReadValue<float>();

        if (virtualCamera != null && scrollInput != 0)
        {
            virtualCamera.m_Lens.FieldOfView += scrollInput * zoomSpeed; 
            virtualCamera.m_Lens.FieldOfView = Mathf.Clamp(virtualCamera.m_Lens.FieldOfView,minFov, maxFov);
        }
    }
}
