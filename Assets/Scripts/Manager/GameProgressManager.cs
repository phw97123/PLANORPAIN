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
    private string[] _gameIconPath = { "game1Image", "game2Image", "game3Image", "game4Image", "game5Image" };
    private GameProgressManager() { }

    private void Awake()
    {
        RemainingGames = new Dictionary<GameScene, string>();
        for (int i = 0; i < Enum.GetValues(typeof(GameScene)).Length - 1; i++) 
        {
            RemainingGames.Add((GameScene)(i + 1), $"Sprites/plannerTest/{_gameIconPath[i]}");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(CurGame.ToString());
        RemainingGames.Remove(CurGame);
        CurDay = (Day)((int)CurDay + 1);
    }
    public void LoadPlannerScene()
    {
        //SceneManager.LoadScene("StartScene");
        SceneManager.LoadScene("YCYMainSceneUIPrefab");

    }
}
