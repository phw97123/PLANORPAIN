using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestObject : MonoBehaviour, IInteractable
{
    //[SerializeField] private GameObject _interactionUI;
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
            //_interactionUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _outline.OutlineWidth = 0f;
            Debug.Log("Interact : Off");
            //_interactionUI.SetActive(false);
        }
    }

    public void OnInteract()
    {
        Debug.Log("Interact : TestObject");
    }

}
