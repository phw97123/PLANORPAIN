using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Graph : MonoBehaviour
{
    private DevelopGameManager _developGameManager;

    private int _curOrderIdx = 1;
    private int[] _searchOrder = new int[] { 1, 2, 7, 6, 8, 3, 4, 5 };

    private Node[] nodeList;

    private void Awake()
    {
        nodeList = GetComponentsInChildren<Node>();
        // 게임 매니저를 통해서 미니 게임을 관리할 매니저 호출
        _developGameManager = GameManager.Instance.GetMiniGameManager<DevelopGameManager>();
    }

    public bool SearchNode(int nodeNum)
    {
        if (nodeNum == _searchOrder[_curOrderIdx])
        {
            _curOrderIdx++;
            if (_curOrderIdx == _searchOrder.Length)
            {
                _developGameManager.GameOver();
            } else
            {
                SoundManager.Instance.Play(Strings.Sounds.DEVELOP_GAME_SEARCH_SUCCESS, volume: 0.7f);
            }
            return true;
        } else
        {
            _curOrderIdx = 1;
            for (int i = 1; i < nodeList.Length; i++)
            {
                nodeList[i].SetNodeActive(false);
            }
            _developGameManager.Respawn();
            _developGameManager.UpdateTryCount();

            return false;
        }
    }
}
