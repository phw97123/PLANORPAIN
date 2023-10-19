using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strings
{
    public class PopupContent
    {
        public const string DEVELOP_GAME_NOTIFICATION = "WASD로 움직이면서\n모든 노드를 순서대로 \n활성화 시키세요!";
        public const string CLEANING_GAME_NOTIFICATION = "WASD로 움직이면\n청소를 할 수 있어요!"; 
    }

    public class PopupButtons
    {
        // CONFIRM BUTTON
        public const string CONFIRM_ACTIVE = "활성화";

        // CANCEL BUTTON
        public const string CANCEL = "취소";
        public const string CLOSE = "닫기";

        // OK BUTTON
        public const string OK = "확인";
    }

    public class Sprites
    {
        public const string LOADING_CLEANING_IMAGE = "LoadingScene/loading_cleaning";
        public const string LOADING_WORKING_IMAGE = "LoadingScene/loading_work";
        public const string LOADING_DEVELOP_IMAGE = "LoadingScene/loading_develop";
        public const string LOADING_GAME_IMAGE = "LoadingScene/loading_game";
        public const string LOADING_OUTING_IMAGE = "LoadingScene/loading_outing";
    }

    public class Sounds
    {
        // 개발하기 미니 게임 사운드
        public const string DEVELOP_GAME_BGM = "DevelopGameScene/developgamescene_bgm";
        public const string DEVELOP_GAME_SEARCH_SUCCESS = "DevelopGameScene/developgamescene_search_success";
        public const string DEVELOP_GAME_SEARCH_FAIL = "DevelopGameScene/developgamescene_search_fail";
    }
}
