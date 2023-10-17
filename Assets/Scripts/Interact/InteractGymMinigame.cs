using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractGymMinigame : MonoBehaviour
{
    [SerializeField] private BackSquatMiniGameUI _gameUI;
    private Outline _outline;
    private bool _isStartMiniGame = false;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _outline.OutlineWidth = 6f;
            SceneVisibilityManager.instance.TogglePicking(gameObject, true);
            _isStartMiniGame = true;
            Debug.Log("Interact : On");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _outline.OutlineWidth = 0f;
            _isStartMiniGame = false;
            Debug.Log("Interact : Off");
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (_isStartMiniGame)
            {
                Debug.Log("Interact : TestObject");
                _gameUI.StartMiniGame();
                _outline.OutlineWidth = 0f;
            }
        }
    }
}
