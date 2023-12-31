using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine playerStateMachine;
    protected readonly PlayerGroundData groundData;

    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        this.playerStateMachine = playerStateMachine;
        groundData = playerStateMachine.Player.Data.GroundData;
    }

    public virtual void Enter()
    {
        AddInputActionsCallbacks();
    }

    public virtual void Exit()
    {
        RemoveActionsCallbacks();
    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Update()
    {
        Move();
    }

    protected virtual void AddInputActionsCallbacks()
    {
        PlayerInput input = playerStateMachine.Player.Input;
        input.PlayerActions.Movement.canceled += OnMovementCanceled;
        input.PlayerActions.Run.started += OnRunStarted;

        input.PlayerActions.Jump.started += OnJumpStarted;
    }

    protected virtual void RemoveActionsCallbacks()
    {
        PlayerInput input = playerStateMachine.Player.Input;
        input.PlayerActions.Movement.canceled -= OnMovementCanceled;
        input.PlayerActions.Run.started -= OnRunStarted;

        input.PlayerActions.Jump.started -= OnJumpStarted;
    }
    protected virtual void OnRunStarted(InputAction.CallbackContext context)
    {

    }
    protected virtual void OnMovementCanceled(InputAction.CallbackContext context)
    {

    }

    protected virtual void OnAttackPerformed(InputAction.CallbackContext context)
    {
        playerStateMachine.IsAttacking = true;
    }

    protected virtual void OnAttackCanceled(InputAction.CallbackContext context)
    {
        playerStateMachine.IsAttacking = false;
    }

    protected virtual void OnJumpStarted(InputAction.CallbackContext context)
    {

    }

    private void ReadMovementInput()
    {
        playerStateMachine.MovementInput = playerStateMachine.Player.Input.PlayerActions.Movement.ReadValue<Vector2>();
    }

    protected void StartAnimation(int animationHash)
    {
        playerStateMachine.Player.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        playerStateMachine.Player.Animator.SetBool(animationHash, false);
    }

    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();
        Rotate(movementDirection);
        Move(movementDirection);
    }

    private Vector3 GetMovementDirection()
    {
        Vector3 forward = playerStateMachine.MainCameraTransform.forward;
        Vector3 right = playerStateMachine.MainCameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        return forward * playerStateMachine.MovementInput.y + right * playerStateMachine.MovementInput.x;
    }

    private void Rotate(Vector3 movementDirection)
    {
        if (movementDirection != Vector3.zero)
        {
            Transform playerTransform = playerStateMachine.Player.transform;
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);

            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, playerStateMachine.RotationDamping * Time.deltaTime);
        }
    }

    private void Move(Vector3 movementDirection) // 여기서 동작을 하면서, rigidbody를 막고 있음. velocity를 임의로 조작하면서 생기는 문제. // velocity 보다는 AddForce를 이용. 중력간의 영향을 주는 걸 코드로 설정..
    {
        Player player = playerStateMachine.Player;
        float movementSpeed = GetMovementSpeed();
        player.Rigidbody.MovePosition(player.transform.position + movementDirection * movementSpeed * Time.deltaTime);

    }

    private float GetMovementSpeed()
    {
        float movementSpeed = playerStateMachine.MovementSpeed * playerStateMachine.MovementSpeedModifier;
        return movementSpeed;
    }

    protected float GetNormalizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

        if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
        {
            return nextInfo.normalizedTime;
        }
        else if (!animator.IsInTransition(0) && currentInfo.IsTag(tag)) 
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }
}