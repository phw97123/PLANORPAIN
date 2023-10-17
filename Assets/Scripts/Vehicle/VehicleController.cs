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
    private Rigidbody _rigidbody;
    private float _downFroceValue = 100f;
    private float _radius = 6f;

    private IInteractable _interactable;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = new Vector3(0, -1, 0);
    }

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
        AddDownForce();
    }

    private void AddDownForce()
    {
        _rigidbody.AddForce(-transform.up * _downFroceValue * _rigidbody.velocity.magnitude);
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

        float leftAngle = 0f;
        float rightAngle = 0f;
        if (_curDriveInput.x > 0)
        {   // rear tracks size is set to 1.5f          wheel base has been set to 2.55f
            leftAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (_radius + (1.5f / 2)));
            rightAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (_radius - (1.5f / 2)));
        }
        else if (_curDriveInput.x < 0)
        {
            leftAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (_radius - (1.5f / 2)));
            rightAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (_radius + (1.5f / 2)));
        }

        _wheelCols[0].steerAngle = rightAngle * _curDriveInput.x;
        _wheelCols[2].steerAngle = leftAngle * _curDriveInput.x;

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

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && _interactable != null)
        {
            _interactable.OnInteract();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            _interactable = other.GetComponent<IInteractable>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            _interactable = null;
        }
    }
}
