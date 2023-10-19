using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum Day { Monday, Tuesday, Wednesday, Thursday, Friday }

public class GameManager : Singleton<GameManager>
{
    // �� �̴� ���ӵ��� �����ϴ� �̴� ���� �Ŵ������� �����ϴ� ��ųʸ�
    private Dictionary<string, MonoBehaviour> _miniGameManagers = new Dictionary<string, MonoBehaviour>();

    public Day CurDay = Day.Monday;
    public Scenes[] GameSceneDB = { Scenes.Unknown, Scenes.CleaningGameScene, Scenes.ConvenienceStoreScene, Scenes.DevelopGameScene, Scenes.DodgeGameScene, Scenes.DrivingScene };
    public Scenes CurGame = Scenes.Unknown;
    public Dictionary<Scenes, string> RemainingGames;
    public Dictionary<Scenes, string> UsingGames;
    public List<int> GameStars;
    public int CurStar; // �� �Ѿ�� ���� ���� ������ 0~3�� ����
    public bool IsGoodEnding { get; private set; }
    public bool gameEnd {  get; private set; }
    private string[] _gameIconPath = { 
        Strings.Sprites.CLEANING_GAME_ICON_IMAGE,
        Strings.Sprites.WORKING_GAME_ICON_IMAGE,
        Strings.Sprites.DEVELOP_GAME_ICON_IMAGE,
        Strings.Sprites.PLAY_GAME_ICON_IMAGE,
        Strings.Sprites.OUTING_GAME_ICON_IMAGE,
    };

    // �̴� ���� �Ŵ��� ȣ�� �� ���
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
            RemainingGames.Add(GameSceneDB[i + 1], _gameIconPath[i]);
            // ���߿� ResourceManager�̿�
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
        else gameEnd = true;
    }
    public void LoadPlannerScene()
    {
        GameStars.Add(CurStar);
        SceneManagerEx.Instance.LoadScene(Scenes.MainScene);
    }
    public void LoadEndingScene()
    {
        int totalStar = 0;
        foreach(int star in GameStars)
        {
            totalStar += star;
        }
        if (totalStar >= 10) IsGoodEnding = true;
        SceneManagerEx.Instance.LoadScene(Scenes.EndingScene);
    }
}
