using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private const int INACTIVE = 0;
    private const int ACTIVE = 1;

    [SerializeField] private GameObject _interactPanelUI;
    [SerializeField] private bool _isActive;
    [SerializeField] private Material[] matList;

    private int _nodeNum;
    private MeshRenderer _meshRenderer;

    private Graph _graph;
    private UI_Popup _uiPopup;

    private void Awake()
    {
        _nodeNum = int.Parse((name[name.Length - 1]).ToString());
        _meshRenderer = GetComponent<MeshRenderer>();
        _graph = GetComponentInParent<Graph>();
        _uiPopup = UIManager.Instance.GetUIComponent<UI_Popup>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // TODO "Player" Tag 추가 후 Tag 비교로 변경
        if (other.gameObject.name == "Player" && !_isActive)
        {
            _uiPopup.ShowPopup(name, "활성화", "취소", () => SearchThisNode(), null);
        }
    }

    private void SearchThisNode()
    {
        if (_graph.SearchNode(_nodeNum))
        {
            SetNodeActive(true);
        }
    }

    public void SetNodeActive(bool isActive)
    {
        _isActive = isActive;
        if (isActive) _meshRenderer.material = matList[ACTIVE];
        else _meshRenderer.material = matList[INACTIVE];
    }
}
