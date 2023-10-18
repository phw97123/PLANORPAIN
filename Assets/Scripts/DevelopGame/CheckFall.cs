using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFall : MonoBehaviour
{
    private DevelopGameManager _developGameManager;

    private void Awake()
    {
        // ���� �Ŵ����� ���ؼ� �̴� ������ ������ �Ŵ��� ȣ��
        
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
