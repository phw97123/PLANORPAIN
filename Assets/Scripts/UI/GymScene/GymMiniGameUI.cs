using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GymMiniGameUI : MonoBehaviour
{
    [SerializeField] private BackSquatMiniGameUI _bsGameUI;
    [SerializeField] private TreadmilMiniGameUI _tmGameUI;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _door;
    [SerializeField] private InteractGymToOutPoint _interactGTOPoint;


    public int selector = 0;
    public bool isInterct = false;

    private Vector3 _originPlayerPosition;
    private bool _isPlayBackSquat = false;
    private bool _isPlayTreadmil = false;

    private void Start()
    {
        _originPlayerPosition = _player.transform.position;
        _door.GetComponent<Collider>().enabled = false;
        StartCoroutine(UpdateDoorColliderCO());
    }

    IEnumerator UpdateDoorColliderCO()
    {
        while (true)
        {
            if (_isPlayBackSquat && _isPlayTreadmil)
            {
                Cursor.lockState = CursorLockMode.None;
                _interactGTOPoint.MakeOutLine();
                _door.GetComponent<Collider>().enabled = true;
                break;
            }
            yield return null;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (isInterct)
        {
            if (context.phase == InputActionPhase.Started)
            {
                switch (selector)
                {
                    case 1:
                        if (!_isPlayBackSquat)
                            _bsGameUI.StartMiniGame();
                        _isPlayBackSquat = true;
                        break;
                    case 2:
                        if (!_isPlayTreadmil)
                            _tmGameUI.StartMiniGame();
                        _isPlayTreadmil = true;
                        break;
                    case -1:
                        if (_isPlayBackSquat && _isPlayTreadmil)
                            _interactGTOPoint.OnInteract();
                        break;
                }
            }
        }
    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            switch (selector)
            {
                case 1:
                    _bsGameUI.OnHitGauge(context);
                    break;
                case 2:
                    _tmGameUI.OnHitBar(context);
                    break;
            }
        }
    }

    public void OnRespawn(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            _player.transform.position = _originPlayerPosition;
    }

}
