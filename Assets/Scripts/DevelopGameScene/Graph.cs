using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    private int _curOrderIdx = 1;
    private int[] _searchOrder = new int[] { 1, 2, 7, 6, 8, 3, 4, 5 };

    private Node[] nodeList;

    private void Awake()
    {
        nodeList = GetComponentsInChildren<Node>();
    }

    public bool SearchNode(int nodeNum)
    {
        if (nodeNum == _searchOrder[_curOrderIdx])
        {
            _curOrderIdx++;
            return true;
        } else
        {
            _curOrderIdx = 1;
            for (int i = 1; i < nodeList.Length; i++)
            {
                nodeList[i].SetNodeActive(false);
            }
            return false;
        }
    }
}
