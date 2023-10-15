using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class VehicleController : MonoBehaviour
{
    [SerializeField] private WheelCollider[] _wheelCols = new WheelCollider[4];
    [SerializeField] private GameObject[] _wheels = new GameObject[4];

    private Vector2 _curDriveInput;

    private void Start()
    {
        for(int i = 0; i < _wheelCols.Length; i++)
        {
            _wheelCols[i].transform.position = _wheels[i].transform.position;
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        for(int i = 0; i < _wheelCols.Length; i++)
        {
            Quaternion quaternion;
            Vector3 position;
            _wheelCols[i].GetWorldPose(out position, out quaternion);
            _wheels[i].transform.SetPositionAndRotation(position, quaternion);
        }

        _wheelCols[0].steerAngle = _curDriveInput.x * 45f;
        _wheelCols[2].steerAngle = _curDriveInput.x * 45f;

        for (int i = 0; i < _wheelCols.Length; i++)
        {
            _wheelCols[i].motorTorque = _curDriveInput.y * (400f);
        }

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
