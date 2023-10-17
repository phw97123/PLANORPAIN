using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Day { Monday, Tuesday, Wednesday, Thursday, Friday }
public enum GameScene { Null, Game1, Game2, Game3, Game4, Game5 }
public struct GameData
{
    public GameScene GameType;
    public Image GameIcon;

    public GameData(GameScene gameScene, Image image) {  GameType = gameScene; GameIcon = image; }
}

public class GameProgressManager : Singleton<GameProgressManager>
{
    public Day CurDay = Day.Monday;
    public GameScene CurGame = GameScene.Null;
    public Dictionary<GameScene, string> RemainingGames;
    public Dictionary<GameScene, string> UsingGames;
    public List<int> GameStars;
    public int CurStar; // 씬 넘어가기 전에 게임 끝내고 0~3값 대입
    private string[] _gameIconPath = { "game1Image", "game2Image", "game3Image", "game4Image", "game5Image" };

    private GameProgressManager() { }

    private void Awake()
    {
        RemainingGames = new Dictionary<GameScene, string>();
        for (int i = 0; i < Enum.GetValues(typeof(GameScene)).Length - 1; i++) 
        {
            RemainingGames.Add((GameScene)(i + 1), $"Sprites/plannerTest/{_gameIconPath[i]}");
        }
        UsingGames = new Dictionary<GameScene, string>();
        GameStars = new List<int>();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(CurGame.ToString());
        RemainingGames.Remove(CurGame);
        UsingGames.Add(CurGame, $"Sprites/plannerTest/{_gameIconPath[(int)CurGame - 1]}");
        if (CurDay != Day.Friday) CurDay = (Day)((int)CurDay + 1);
        //여기 마지막 날 추가 처리하기!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11
    }
    public void LoadPlannerScene()
    {
        GameStars.Add(CurStar);
        SceneManager.LoadScene("MainScene");

    }
}
