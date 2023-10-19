using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float  drag = 0.3f;

    private Vector3 dampingVelocity;
    private Vector3 impact; 
    private float verticalVelocity;

    public Vector3 Movement => Vector3.up * verticalVelocity;

    private void Update()
    {
        if (verticalVelocity <0f && characterController.isGrounded) 
        {
            verticalVelocity = Physics.gravity.y * Time.deltaTime;
            impact = Vector3.SmoothDamp(impact, Vector3.zero, ref dampingVelocity,drag);
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
    }
}
