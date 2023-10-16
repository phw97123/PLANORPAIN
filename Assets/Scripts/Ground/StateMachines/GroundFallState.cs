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
    public GameObject thisObject;
    public bool isReadyToDestroy;

    public override void Enter()
    {
        base.Enter();
        GroundTransform = groundStateMachine.Ground.GetComponent<Transform>();
    }

    public override void Exit()
    {
        base.Exit();
        // 오브젝트 파괴시키는 메서드
        thisObject = groundStateMachine.Ground.gameObject;
        DestroyGameObject( thisObject );
    }

    public override void Update()
    {
        base.Update();
        while (GroundTransform.position.y > -3.5f)
        {
            GroundTransform.Translate(Vector3.down * Time.deltaTime * 0.5f); // 임시속도 : 0.5f
        }
        if (GroundTransform.position.y < -3.49f)
        {
            isReadyToDestroy = true;
            Exit();
        }
    }

    public void DestroyGameObject(GameObject go)
    {
        if (go != null)
        {
            Object.Destroy(go);
        }
    }
}
