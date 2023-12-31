using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [field: Header("References")]
    [field: SerializeField] public PlayerSO Data {get; private set;}

    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerInput Input { get; private set; }
    public CapsuleCollider Collider { get; private set; }

    [field: SerializeField]  public LayerMask groundLayerMask { get; private set; }
    [field: SerializeField]  public LayerMask LavaLayerMask { get; private set; }

    public ForceReceiver ForceReceiver { get; private set; }

    private PlayerStateMachine playerStateMachine;

    public GameObject Equipment; 

    private void Awake()
    {
        AnimationData.Initialize();

        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        Input = GetComponent<PlayerInput>();
        Collider = GetComponent<CapsuleCollider>();
        //ForceReceiver = GetComponent<ForceReceiver>();

        playerStateMachine = new PlayerStateMachine(this);
    }

    private void Start()
    {
        playerStateMachine.ChangeState(playerStateMachine.IdleState);
    }

    private void Update()
    {
        playerStateMachine.HandleInput();
        playerStateMachine.Update();
    }

    private void FixedUpdate()
    {
        playerStateMachine.PhysicsUpdate();
    }

    public void EnableActions(params InputActions[] actionNames)
    {
        Input.OnDisable(); 
        foreach (InputActions actionName in actionNames)
        {
            InputAction action = Input.InputActions.FindAction(actionName.ToString());
            if (action != null)
                action.Enable();
            else
                Debug.LogError($"{action} 는 존재하지 않습니다."); 
        }
    }

    public bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (Vector3.up * 0.01f) , Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f)+ (Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }

    public bool IsJumping()
    {
        Ray[] rays = new Ray[4]
{
            new Ray(transform.position + (transform.forward * 0.2f) + (Vector3.up * 0.01f) , Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f)+ (Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
};

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask) || Physics.Raycast(rays[i], 0.1f, LavaLayerMask))
            {
                return true;
            }
        }

        return false;
    }

    public bool IsStepping()
    {
        Ray[] rays = new Ray[4]
{
            new Ray(transform.position + (transform.forward * 0.2f) + (Vector3.up * 0.01f) , Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f)+ (Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
};

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.2f, LavaLayerMask))
            {
                return true;
            }
        }
        return false;
    }
}
