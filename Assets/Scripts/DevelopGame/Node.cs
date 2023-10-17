using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private const int INACTIVE = 0;
    private const int ACTIVE = 1;

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
    }

    private void Start()
    {
        _uiPopup = UIManager.Instance.GetUIComponent<UI_Popup>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !_isActive)
        {
            _uiPopup.ShowPopup(name, Strings.PopupButtons.CONFIRM_ACTIVE, Strings.PopupButtons.CANCEL, () => SearchThisNode(), null);
            _uiPopup.SetContextFontSize(80);
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
