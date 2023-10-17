using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public static GroundManager GInstance;

    public Player player;

    public List<GameObject> grounds;

    public GameObject groundPiece;

    public bool isDelay;
    public bool isCollided;

    public LayerMask groundLayerMask;

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
        grounds = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++) 
        {
            grounds.Add(transform.GetChild(i).gameObject);
        }
    }

    public void Update()
    {
        if (!isDelay)
        {
            isDelay = true;
            StartCoroutine(ShiverGround());
            StartCoroutine(CheckPlayerOnGround());
        }
    }

    IEnumerator ShiverGround()
    {
        // ���� ������Ʈ ����
        int randNum = UnityEngine.Random.Range(0, grounds.Count() - 1);
        groundPiece = grounds[randNum];

        Debug.Log($"{randNum}��° �� ShiverState��");

        // ���� ������Ʈ�� ground -> groundStateMachine �ҷ�����
        var groundStateMachine = groundPiece.GetComponent<Ground>().groundStateMachine;
        // Shiver ���·� �ҷ����� ����, bool�� true�� �ٲ��ֱ�
        groundStateMachine.IsShivering = true;

        // �迭 �ٽ� �������
        grounds.Remove(groundPiece);
        yield return new WaitForSeconds(5f);
        isDelay = false;
    }


    IEnumerator CheckPlayerOnGround()
    {
        Vector3 playerPosition = player.transform.position; // �÷��̾� ��ġ
        Ray ray = new Ray(playerPosition, new Vector3(0, -2, 0));
        RaycastHit hit;
        

        if (Physics.Raycast(ray, out hit, 0.7f, groundLayerMask))
        {
            GameObject groundObject = hit.transform.gameObject;
            Debug.Log("�÷��̾ " + groundObject.name + " ���� �ֽ��ϴ�!");
            var groundStateMachine = groundObject.GetComponent<Ground>().groundStateMachine;
            groundStateMachine.IsShivering = true;
            grounds.Remove(groundObject);
        }

        yield return null;
    }

}
