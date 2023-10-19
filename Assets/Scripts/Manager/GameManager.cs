using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum Day { Monday, Tuesday, Wednesday, Thursday, Friday }

public class GameManager : Singleton<GameManager>
{
    // 각 미니 게임들을 관리하는 미니 게임 매니저들을 저장하는 딕셔너리
    private Dictionary<string, MonoBehaviour> _miniGameManagers = new Dictionary<string, MonoBehaviour>();

    public Day CurDay = Day.Monday;
    public Scenes[] GameSceneDB = { Scenes.Unknown, Scenes.CleaningGameScene, Scenes.ConvenienceStoreScene, Scenes.DevelopGameScene, Scenes.DodgeGameScene, Scenes.DrivingScene };
    public Scenes CurGame = Scenes.Unknown;
    public Dictionary<Scenes, string> RemainingGames;
    public Dictionary<Scenes, string> UsingGames;
    public List<int> GameStars;
    public int CurStar; // 씬 넘어가기 전에 게임 끝내고 0~3값 대입
    private string[] _gameIconPath = { "game1", "game2", "game3", "game4", "game5" };

    // 미니 게임 매니저 호출 시 사용
    // ex) GameManager.Instance.GetMiniGameManager<DevelopGameManager>();
    public T GetMiniGameManager<T>() where T : MonoBehaviour
    {
        string key = typeof(T).Name;
        if (!_miniGameManagers.ContainsKey(key))
        {
            var obj = Instantiate(Resources.Load($"Prefabs/MiniGame/{key}"));
            _miniGameManagers.Add(key, obj.GetComponent<T>());
        }
        return (T)_miniGameManagers[key];
    }

    public void RemoveMiniGameManager<T>() where T : MonoBehaviour
    {
        string key = typeof(T).Name;
        if (_miniGameManagers.ContainsKey(key))
        {
            _miniGameManagers.Remove(key);
        }
    }

    private void Awake()
    {
        RemainingGames = new Dictionary<Scenes, string>();
        for (int i = 0; i < GameSceneDB.Length - 1; i++)
        {
            RemainingGames.Add(GameSceneDB[i + 1], $"Planner/{_gameIconPath[i]}");
            // 나중에 ResourceManager이용
        }
        UsingGames = new Dictionary<Scenes, string>();
        GameStars = new List<int>();
    }

    public void LoadGameScene()
    {
        SceneManagerEx.Instance.LoadScene(Scenes.LoadingScene, CurGame);
        UsingGames.Add(CurGame, RemainingGames[CurGame]);
        RemainingGames.Remove(CurGame);
        if (CurDay != Day.Friday) CurDay = (Day)((int)CurDay + 1);
        //여기 마지막 날 추가 처리하기!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11
    }
    public void LoadPlannerScene()
    {
        GameStars.Add(CurStar);
        SceneManagerEx.Instance.LoadScene(Scenes.MainScene);
    }
}
