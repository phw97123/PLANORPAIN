using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_DevelopGameScene : UIBase
{
    [SerializeField] private TMP_Text _searchTryCountText;
    [SerializeField] private GameObject _nodeIconsParent;

    private Image[] _nodeIconImageList;

    private int _curIconIdx = 1;

    private void Awake()
    {
        int length = _nodeIconsParent.transform.childCount;
        _nodeIconImageList = new Image[length];
        for (int i = 0; i < length; i++)
        {
            _nodeIconImageList[i] = _nodeIconsParent.transform.GetChild(i).GetComponent<Image>();
        }
    }

    public void SetSearchTryCountText(int tryCount)
    {
        _searchTryCountText.text = $"{tryCount}È¸ ½Ãµµ";
    }

    public void SetDefaultNodeIcons()
    {
        _curIconIdx = 1;
        for (int i = 1; i < _nodeIconImageList.Length; i++)
        {
            _nodeIconImageList[i].sprite = ResourceManager.Instance.LoadSprite(Strings.Sprites.INACTIVE_NODE_ICON);
        }
    }

    public void UpdateNodeIcon()
    {
        if (_curIconIdx < _nodeIconImageList.Length)
        {
            _nodeIconImageList[_curIconIdx].sprite = ResourceManager.Instance.LoadSprite(Strings.Sprites.ACTIVE_NODE_ICON);
        }
        _curIconIdx++;
    }
}
