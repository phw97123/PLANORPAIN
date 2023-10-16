using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InteractGymMinigame : MonoBehaviour
{
    [SerializeField] private GameObject _miniGameUI;
    private Outline _outline;

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
