using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DodgeGameManager : MonoBehaviour
{
    public GameObject player;
    public static DodgeGameManager DInstance;

    private UI_Popup uiPopup;
    private UI_GameEndPopup uiGameEndPopup;
    private UI_DodgeGameScene uiDodgeGameScene;

    public float currentHp;
    public bool isEnded;
    public bool isLavaEffectPlaying;

    private void Awake()
    {
        if (DInstance == null)
        {
            DInstance = this;
        }
        else
        {
            if (DInstance != this)
            {
                Destroy(this.gameObject);
            }
        }

        player = GameObject.FindWithTag(Tags.PLAYER);

    }

    private void Start()
    {
        uiPopup = UIManager.Instance.GetUIComponent<UI_Popup>();
        uiGameEndPopup = UIManager.Instance.GetUIComponent<UI_GameEndPopup>();
        uiDodgeGameScene = UIManager.Instance.GetUIComponent<UI_DodgeGameScene>();

        uiPopup.ShowPopup("��鸮�� �������� �������", "OK", null);

        currentHp = player.GetComponent<Player>().Data.MaxHp;
        SoundManager.Instance.Play("DodgeGameScene/DodgeGameBGM", AudioType.BGM);
    }

    private void Update()
    {
        if (player.GetComponent<Player>().IsStepping() && !isEnded)
        {
            currentHp -= 10 * Time.deltaTime;
        }
        if (player.GetComponent<Player>().IsStepping() && !isEnded)
        {
            StartCoroutine(PlayLavaSound());
        }
        if ((currentHp < 0 || float.Parse(uiDodgeGameScene.timerText.text) < 0.1f) && !isEnded)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        isEnded = true;
        uiDodgeGameScene.timerText.text = "0";
        Time.timeScale = 0;
        uiGameEndPopup.SetScore(uiDodgeGameScene.GetScore());
        //GameProgressManager.Instance.CurStar = uiDodgeGameScene.GetScore();
        uiGameEndPopup.ShowPopup();
    }

    IEnumerator PlayLavaSound()
    {
        if (isLavaEffectPlaying)
        {
            yield break; // �̹� ���尡 ��� ���� ��� �ߺ� ��� ����
        }
        isLavaEffectPlaying = true;
        SoundManager.Instance.Play("DodgeGameScene/OnLaveEffect");
        yield return new WaitForSeconds(1f);
        isLavaEffectPlaying = false;
    }
}
