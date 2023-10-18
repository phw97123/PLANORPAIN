using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractGymMinigame : MonoBehaviour
{
    [SerializeField] private MiniGameUI _miniGameUI;
    [SerializeField] private int _miniGameSelect;
    private Outline _outline;
    private bool _isInteract = false;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }

    private void Start()
    {
        StartCoroutine(BlinkOutlingCO());
    }

    IEnumerator BlinkOutlingCO()
    {
        _outline.OutlineWidth = 6f;

        yield return new WaitForSecondsRealtime(2f);

        _outline.OutlineWidth = 0f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_isInteract)
            {
                StartCoroutine(BlinkOutlingCO());
                _miniGameUI.isInterct = true;
                _miniGameUI.selector = _miniGameSelect;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _outline.OutlineWidth = 0f;
            _miniGameUI.isInterct = false;
        }
    }
}
