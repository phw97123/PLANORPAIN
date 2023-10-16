using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GroundFallState : GroundBaseState
{
    public GroundFallState(GroundStateMachine groundStateMachine) : base(groundStateMachine)
    {
    }

    public Transform GroundTransform;

    public override void Enter()
    {
        base.Enter();
        GroundTransform = groundStateMachine.Ground.GetComponent<Transform>();
    }

    public override void Exit()
    {
        base.Exit();
        // ������Ʈ �ı���Ű�� �޼���
    }

    public override void Update()
    {
        base.Update();
        while (GroundTransform.position.y > -3.5f)
        {
            GroundTransform.Translate(Vector3.down * Time.deltaTime * 0.5f); // �ӽüӵ� : 0.5f
        }
    }
}
