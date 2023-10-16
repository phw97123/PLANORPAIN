using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public static GroundManager GInstance;

    public GameObject[] grounds;

    public GameObject groundPiece;

    public bool isDelay;
    public bool isCollided;

    // �̱���
    private void Awake()
    {
        if (GInstance == null)
        {
            GInstance = this;
        }
        else
        {
            if (GInstance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void Start()
    {
        grounds = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) 
        {
            grounds[i] = transform.GetChild(i).gameObject;
        }
    }

    public void Update()
    {
        if (!isDelay)
        {
            isDelay = true;
            StartCoroutine(ShiverGround());
        }
    }

    IEnumerator ShiverGround()
    {
        // ���� ������Ʈ ����
        int randNum = UnityEngine.Random.Range(0, grounds.Length - 1);
        groundPiece = grounds[randNum];

        Debug.Log($"{randNum}��° �� ShiverState��");

        // ���� ������Ʈ�� ground -> groundStateMachine �ҷ�����
        var groundStateMachine = groundPiece.GetComponent<Ground>().groundStateMachine;
        // Shiver ���·� �ҷ����� ����, bool�� true�� �ٲ��ֱ�
        groundStateMachine.IsShivering = true;

        // �迭 �ٽ� �������
        Array.Resize(ref grounds, grounds.Length - 1);
        yield return new WaitForSeconds(5f);
        isDelay = false;
    }

}
