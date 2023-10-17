using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class InteractGymMinigame : MonoBehaviour
{
    [SerializeField] private GameObject _miniGameUI;
    [SerializeField] private GameObject _playerHand;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private AnimatorController _animController;
    private Outline _outline;
    private Transform _transform;
    

    private void Awake()
    {
        _outline = GetComponent<Outline>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
    }

    private void FollowPlayerHand()
    {
        _transform.position = _playerHand.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _outline.OutlineWidth = 6f;
            SceneVisibilityManager.instance.TogglePicking(gameObject, true);
            Debug.Log("Interact : On");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _outline.OutlineWidth = 0f;
            Debug.Log("Interact : Off");
        }
    }

    public void OnInteract()
    {
        Debug.Log("Interact : TestObject");
        _miniGameUI.SetActive(true);
    }
}
