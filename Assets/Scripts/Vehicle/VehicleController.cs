using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class VehicleController : MonoBehaviour
{

    private Vector2 _curDriveInput;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        
    }

    public void OnDriveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            _curDriveInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            _curDriveInput = Vector2.zero;
        }
    }
}
