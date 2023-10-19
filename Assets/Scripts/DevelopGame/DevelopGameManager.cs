using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// �����ϱ� �̴� ������ �����ϴ� �̴� ���� �Ŵ���
public class DevelopGameManager : MonoBehaviour
{
    private Vector3 _playerSpawnPosition = Vector3.zero;

    private int _tryCount = 1;

    private GameObject _player;

    // UI
    private UI_Popup _uiPopup;
    private UI_GameEndPopup _uiGameEndPopup;
    private UI_DevelopGameScene _uiDevelopGameScene;

    private void Awake()
    {
        _player = GameObject.FindWithTag(Tags.PLAYER);
        _playerSpawnPosition = _player.transform.position;

        _player.GetComponent<Player>().EnableActions(InputActions.Movement, InputActions.Run, InputActions.Jump);
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

    // �÷��̾� ������
    public void Respawn()
    {
        _player.transform.position = _playerSpawnPosition;
        SoundManager.Instance.Play(Strings.Sounds.DEVELOP_GAME_SEARCH_FAIL, volume: 0.5f);
    }

    // �õ� Ƚ�� ������Ʈ
    public void UpdateTryCount()
    {
        _tryCount++;
        _uiDevelopGameScene.SetSearchTryCountText(_tryCount);
    }

    // ���� ����
    public void GameOver()
    {
        _uiGameEndPopup.SetScore(GetScore());
        _uiGameEndPopup.ShowPopup();
    }
}
