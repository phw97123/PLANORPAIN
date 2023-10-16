using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPoint : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        Debug.Log("Test Point Interact!!");
    }
}
