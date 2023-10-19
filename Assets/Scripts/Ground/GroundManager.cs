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

    public int score;

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
        grounds = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++) 
        {
            grounds.Add(transform.GetChild(i).gameObject);
        }
    }

    public void Update()
    {
        if (!isDelay && grounds.Count() > 0)
        {
            isDelay = true;
            StartCoroutine(ShiverGround());
        }
        if (!isCollided && grounds.Count() > 0)
        { 
            isCollided = true;
            StartCoroutine(CheckPlayerOnGround());
        }
    }

    IEnumerator ShiverGround()
    {
        // 랜덤 오브젝트 추출
        int randNum = UnityEngine.Random.Range(0, grounds.Count() - 1);
        groundPiece = grounds[randNum];


        // 랜덤 오브젝트의 ground -> groundStateMachine 불러오기
        var groundStateMachine = groundPiece.GetComponent<Ground>().groundStateMachine;
        // Shiver 상태로 불러오기 위해, bool값 true로 바꿔주기
        groundStateMachine.IsShivering = true;

        // 배열 다시 원래대로
        score += 30;
        grounds.Remove(groundPiece);
        yield return new WaitForSeconds(2f);
        isDelay = false;
    }


    IEnumerator CheckPlayerOnGround()
    {
        Vector3 playerPosition = player.transform.position; // 플레이어 위치
        Ray ray = new Ray(playerPosition, new Vector3(0, -2, 0));
        RaycastHit hit;
        

        if (Physics.Raycast(ray, out hit, 0.7f, groundLayerMask))
        {
            GameObject groundObject = hit.transform.gameObject;
            var groundStateMachine = groundObject.GetComponent<Ground>().groundStateMachine;
            groundStateMachine.IsShivering = true;
            grounds.Remove(groundObject);
        }

        score += 30;
        yield return new WaitForSeconds(2f);
        isCollided = false;
    }

}
