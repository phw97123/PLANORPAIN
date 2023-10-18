using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_DevelopGameScene : UIBase
{
    [SerializeField] private TMP_Text _searchTryCountText;

    public void SetSearchTryCountText(int tryCount)
    {
        _searchTryCountText.text = $"{tryCount}È¸ ½Ãµµ";
    }
}
