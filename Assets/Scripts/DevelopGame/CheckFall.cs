using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFall : MonoBehaviour
{
    private DevelopGameManager _developGameManager;

    private void Awake()
    {
        // 게임 매니저를 통해서 미니 게임을 관리할 매니저 호출
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_developGameManager == null) _developGameManager = GameManager.Instance.GetMiniGameManager<DevelopGameManager>();
            _developGameManager.Respawn();
        }
    }
}
