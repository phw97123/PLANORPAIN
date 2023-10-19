


#### StartScene
|기능|기능 설명|스크립트|메서드|
|:---:|:---:|:---:|:---:|
|||[StartScene.cs](https://github.com/phw97123/PLANORPAIN/blob/f13925cf701b6cb917696f02047601c248281a25/Assets/Scripts/Scene/StartScene.cs#L7-L15)|Init()|

<br>
<br>


#### MainScene
|기능|기능 설명|스크립트|메서드|
|:---:|:---|:---:|:---:|
|플래너 팝업 열기|원하는 게임을 선택할 수 있는 플래너 팝업을 연다.|PlannerClickEvent.cs|[Update()](https://github.com/phw97123/PLANORPAIN/blob/f13925cf701b6cb917696f02047601c248281a25/Assets/Scripts/UI/Scene/MainScene/PlannerClickEvent.cs#L9)|
|게임 선택(1)|원하는 게임의 아이콘을 드래그 & 드롭할 수 있다.|[PlannerGameIcon.cs](https://github.com/phw97123/PLANORPAIN/blob/f13925cf701b6cb917696f02047601c248281a25/Assets/Scripts/UI/Planner/PlannerGameIcon.cs#L7)||
|게임 선택(2)|원하는 게임을 드래그 한 후, start 버튼을 누르면 해당 게임의 씬을 로드한다.|[PlannerGameSlot.cs](https://github.com/phw97123/PLANORPAIN/blob/f13925cf701b6cb917696f02047601c248281a25/Assets/Scripts/UI/Planner/PlannerGameSlot.cs#L10)|[OnClickStartButton()](https://github.com/phw97123/PLANORPAIN/blob/f13925cf701b6cb917696f02047601c248281a25/Assets/Scripts/UI/Planner/PlannerGameSlot.cs#L55)|
|게임 선택(3)|UI_planner 팝업에서 플레이한 게임과 결과, 플레이할 수 있는 게임의 아이콘을 표시한다.|[UI_Planner.cs](https://github.com/phw97123/PLANORPAIN/blob/f13925cf701b6cb917696f02047601c248281a25/Assets/Scripts/UI/Planner/UI_Planner.cs#L9)||


<br>
<br>

### 미니게임
#### CleaningGameScene
<br>

* 제한시간 60초 안에 최대한 많은 타일을 청소해야하는 게임.

* 30초가 남았을 때, 고양이가 나타나 청소한 타일을 다시 어지럽힘.

<br>

|기능|기능 설명|스크립트|메서드|
|:---:|:---|:---:|:---:|
|씬 스크립트|씬을 시작한다.|[CleaningGameScene.cs](https://github.com/phw97123/PLANORPAIN/blob/fedb8d0b27f8c3fc22113b649f987d68872caf0a/Assets/Scripts/Scene/CleaningGameScene.cs#L5)||
|미니게임 매니저|게임 로직과 Popup UI를 관리한다.|[CleaningGameManager.cs](https://github.com/phw97123/PLANORPAIN/blob/fedb8d0b27f8c3fc22113b649f987d68872caf0a/Assets/Scripts/CleaningGame/CleaningGameManager.cs#L13)||
|인게임 UI|남은 시간과 획득한 점수를 표시한다.|[CleaningGameSceneUI.cs](https://github.com/phw97123/PLANORPAIN/blob/fedb8d0b27f8c3fc22113b649f987d68872caf0a/Assets/Scripts/UI/Scene/CleaningGameScene/CleaningGameSceneUI.cs#L8)||
|청소 구현|각 캐릭터 태그에 맞게 충돌을 감지하여 바닥 오브젝트를 변경하여 청소 기능을 구현한다.|[ChangeCell.cs](https://github.com/phw97123/PLANORPAIN/blob/fedb8d0b27f8c3fc22113b649f987d68872caf0a/Assets/Scripts/CleaningGame/ChangeCell.cs#L24)|[ChangeCellCoroutine](https://github.com/phw97123/PLANORPAIN/blob/fedb8d0b27f8c3fc22113b649f987d68872caf0a/Assets/Scripts/CleaningGame/ChangeCell.cs#L24)|
|고양이 구현|시간이 30초 남았을 때, 플레이어가 청소한 타일을 방해하는 고양이를 구현한다.|[Cat.cs](https://github.com/phw97123/PLANORPAIN/blob/fedb8d0b27f8c3fc22113b649f987d68872caf0a/Assets/Scripts/Character/Cat/Cat.cs#L7)||

<br>
<br>

#### DevelopGameScene
<br>

* 주어진 Node 탐색을 맵에 있는 Node들을 알맞은 순서로 활성화시켜야 하는 게임.

<br>

|기능|기능 설명|스크립트|메서드|
|:---:|:---|:---:|:---:|
|||||
