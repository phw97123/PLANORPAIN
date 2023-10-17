using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundStateMachine : StateMachine
{
    public Ground Ground { get; }
    public GroundIdleState IdleState { get; }
    public GroundShiverState ShiverState { get; }
    public GroundFallState FallState { get; }

    public bool IsShivering { get; set; }
    public bool IsShiverStarted { get; set; }
    
    public GroundStateMachine(Ground ground)
    {
        this.Ground = ground;

        IdleState = new GroundIdleState(this);
        ShiverState = new GroundShiverState(this);
        FallState = new GroundFallState(this);
    }

    // 조건을 받고 IsShiver = True로 만들어주는 메서드 
}
