using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }

    public PlayerIdleState IdleState {get;}
    public PlayerWalkState WalkState {get;}

    public Transform MainCameraTransform { get; set; }

    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;
    public float RotationDamping { get; private set; }

    public PlayerStateMachine(Player player)
    {
        this.Player = player;

        IdleState = new PlayerIdleState(this);
        WalkState = new PlayerWalkState(this);

        MainCameraTransform = Camera.main.transform;

        MovementSpeed = player.Data.GroundData.BaseSpeed;
        RotationDamping = player.Data.GroundData.BaseRotationDamping;
    }
}