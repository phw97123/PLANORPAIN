using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DodgeManager : MonoBehaviour
{
    public GameObject player;
    public static DodgeManager DInstance;

    private UI_Popup uiPopup;
    private UI_GameEndPopup uiGameEndPopup;
    private UI_DodgeGameScene uiDodgeGameScene;

    public float currentHp;

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

        uiPopup.ShowPopup("흔들리는 지형에서 벗어나세요", "OK", null);

        currentHp = player.GetComponent<Player>().Data.MaxHp;
    }

    private void Update()
    {
        if (player.GetComponent<Player>().IsStepping())
        {
            currentHp -= 10 * Time.deltaTime;
        }
        if (currentHp < 0 || float.Parse(uiDodgeGameScene.timerText.text) < 0.1f)
        {
            Time.timeScale = 0;
            GameOver();
        }
    }
    public void GameOver()
    {
        uiDodgeGameScene.timerText.text = "0";
        uiGameEndPopup.SetScore(uiDodgeGameScene.GetScore());
        uiGameEndPopup.ShowPopup(() => { SceneManager.LoadScene("MainScene"); });
    }
}
