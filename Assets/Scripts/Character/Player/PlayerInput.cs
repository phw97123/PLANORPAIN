using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerInputActions InputActions { get; private set; }
    public PlayerInputActions.PlayerActions PlayerActions { get; private set; }

    public CinemachineVirtualCamera virtualCamera;
    public float zoomSpeed = 5.0f;
    public float minFov = 20.0f;
    public float maxFov = 50.0f; 
    private void Awake()
    {
        InputActions = new PlayerInputActions();
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

        if (scrollInput != 0)
        {
            virtualCamera.m_Lens.FieldOfView += scrollInput * zoomSpeed; 
            virtualCamera.m_Lens.FieldOfView = Mathf.Clamp(virtualCamera.m_Lens.FieldOfView,minFov, maxFov);
        }
    }
}
