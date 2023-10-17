using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Graph : MonoBehaviour
{
    // TODO GameManager가 각 미니 게임을 관리하는 관리자를 갖고 있고, 해당 관리자에게 게임 정보 업데이트를 요청하는 방식으로 수정
    [SerializeField] private Transform _playerSpawnPosition;

    private int _curOrderIdx = 1;
    private int[] _searchOrder = new int[] { 1, 2, 7, 6, 8, 3, 4, 5 };

    private Node[] nodeList;

    private int tryCount = 1;

    private UI_GameEndPopup _uiGameEndPopup;
    private UI_DevelopGameScene _uiDevelopGameScene;

    private GameObject _player;

    private void Awake()
    {
        nodeList = GetComponentsInChildren<Node>();
        // TODO 게임 매니저나 각 미니 게임 관리자 클래스를 통해 받아오기 or 요청하는 방식으로 수정
        _player = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        _uiGameEndPopup = UIManager.Instance.GetUIComponent<UI_GameEndPopup>();
        _uiDevelopGameScene = UIManager.Instance.GetUIComponent<UI_DevelopGameScene>();
    }

    public bool SearchNode(int nodeNum)
    {
        if (nodeNum == _searchOrder[_curOrderIdx])
        {
            _curOrderIdx++;
            if (_curOrderIdx == _searchOrder.Length)
            {
                _uiGameEndPopup.SetScore(GetScore());
                _uiGameEndPopup.ShowPopup(() => { SceneManager.LoadScene("MainScene"); });
            }
            return true;
        } else
        {
            _curOrderIdx = 1;
            for (int i = 1; i < nodeList.Length; i++)
            {
                nodeList[i].SetNodeActive(false);
            }
            tryCount++;
            _uiDevelopGameScene.SetSearchTryCountText(tryCount);

            // 플레이어 리스폰
            _player.transform.position = _playerSpawnPosition.position;
            return false;
        }
    }

    private int GetScore()
    {
        if (tryCount <= 5) return 3;
        if (tryCount <= 10) return 2;
        else return 1;
    }
}
