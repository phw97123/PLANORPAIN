using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevelopGameManager : MonoBehaviour
{
    // TODO GameManager가 각 미니 게임을 관리하는 관리자를 갖고 있도록 수정
    [SerializeField] private Transform _playerSpawnPosition;

    private int _tryCount = 1;

    private GameObject _player;

    // UI
    private UI_Popup _uiPopup;
    private UI_GameEndPopup _uiGameEndPopup;
    private UI_DevelopGameScene _uiDevelopGameScene;

    private void Awake()
    {
        _player = GameObject.FindWithTag(Tags.PLAYER);
    }

    private void Start()
    {
        _uiPopup = UIManager.Instance.GetUIComponent<UI_Popup>();
        _uiGameEndPopup = UIManager.Instance.GetUIComponent<UI_GameEndPopup>();
        _uiDevelopGameScene = UIManager.Instance.GetUIComponent<UI_DevelopGameScene>();

        _uiPopup.ShowPopup(Strings.PopupContent.DEVELOP_GAME_NOTIFICATION, Strings.PopupButtons.OK, null);
    }

    private int GetScore()
    {
        if (_tryCount <= 5) return 3;
        if (_tryCount <= 10) return 2;
        else return 1;
    }

    // 플레이어 리스폰
    public void Respawn()
    {
        _player.transform.position = _playerSpawnPosition.position;
    }

    // 시도 횟수 업데이트
    public void UpdateTryCount()
    {
        _tryCount++;
        _uiDevelopGameScene.SetSearchTryCountText(_tryCount);
    }

    // 게임 종료
    public void GameOver()
    {
        _uiGameEndPopup.SetScore(GetScore());
        _uiGameEndPopup.ShowPopup(() => { SceneManager.LoadScene("MainScene"); });
    }
}
