using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.UIElements;

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
    }

    protected virtual void RemoveActionsCallbacks()
    {
        PlayerInput input = playerStateMachine.Player.Input;
        input.PlayerActions.Movement.canceled -= OnMovementCanceled;
    }

    protected virtual void OnMovementCanceled(InputAction.CallbackContext context)
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

    private void Move(Vector3 movementDirection)
    {
        float movementSpeed = GetMovementSpeed();
        playerStateMachine.Player.CharacterController.Move(
               (movementDirection * movementSpeed) * Time.deltaTime
            );

    }

    private float GetMovementSpeed()
    {
        float movementSpeed = playerStateMachine.MovementSpeed * playerStateMachine.MovementSpeedModifier;
        return movementSpeed;
    }
}