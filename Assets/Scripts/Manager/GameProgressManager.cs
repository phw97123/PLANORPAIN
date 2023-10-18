using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Day { Monday, Tuesday, Wednesday, Thursday, Friday }
public struct GameData
{
    public Scenes GameType;
    public Image GameIcon;

    public GameData(Scenes gameScene, Image image) {  GameType = gameScene; GameIcon = image; }
}

public class GameProgressManager : Singleton<GameProgressManager>
{
    public Day CurDay = Day.Monday;
    public Scenes[] GameSceneDB = { Scenes.Unknown, Scenes.CleaningGameScene, Scenes.ConvenienceStoreScene, Scenes.DevelopGameScene };
    public Scenes CurGame = Scenes.Unknown;
    public Dictionary<Scenes, string> RemainingGames;
    public Dictionary<Scenes, string> UsingGames;
    public List<int> GameStars;
    public int CurStar; // 씬 넘어가기 전에 게임 끝내고 0~3값 대입
    private string[] _gameIconPath = { "game1Image", "game2Image", "game3Image", "game4Image", "game5Image" };

    private GameProgressManager() { }

    private void Awake()
    {
        RemainingGames = new Dictionary<Scenes, string>();
        for (int i = 0; i < GameSceneDB.Length - 1; i++) 
        {
            RemainingGames.Add(GameSceneDB[i + 1], $"Sprites/plannerTest/{_gameIconPath[i]}");
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
