using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Graph : MonoBehaviour
{
    private int _curOrderIdx = 1;
    private int[] _searchOrder = new int[] { 1, 2, 7, 6, 8, 3, 4, 5 };

    private Node[] nodeList;

    private int tryCount = 1;

    private void Awake()
    {
        nodeList = GetComponentsInChildren<Node>();
    }

    public bool SearchNode(int nodeNum)
    {
        if (nodeNum == _searchOrder[_curOrderIdx])
        {
            _curOrderIdx++;
            if (_curOrderIdx == _searchOrder.Length)
            {
                UI_GameEndPopup popup = UIManager.Instance.GetUIComponent<UI_GameEndPopup>();
                popup.SetScore(GetScore());
                popup.ShowPopup(() => { SceneManager.LoadScene("MainScene"); });
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
