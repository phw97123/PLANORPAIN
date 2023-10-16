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

    // 싱글톤
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
        // 랜덤 오브젝트 추출
        int randNum = UnityEngine.Random.Range(0, grounds.Length - 1);
        groundPiece = grounds[randNum];

        Debug.Log($"{randNum}번째 땅 ShiverState로");

        // 랜덤 오브젝트의 ground -> groundStateMachine 불러오기
        var groundStateMachine = groundPiece.GetComponent<Ground>().groundStateMachine;
        // Shiver 상태로 불러오기 위해, bool값 true로 바꿔주기
        groundStateMachine.IsShivering = true;

        // 배열 다시 원래대로
        Array.Resize(ref grounds, grounds.Length - 1);
        yield return new WaitForSeconds(5f);
        isDelay = false;
    }

}
