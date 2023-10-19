


#### StartScene
|기능|기능 설명|스크립트|메서드|
|:---:|:---:|:---:|:---:|
|||[StartScene.cs](https://github.com/phw97123/PLANORPAIN/blob/f13925cf701b6cb917696f02047601c248281a25/Assets/Scripts/Scene/StartScene.cs#L7-L15)|Init()|
<br>
<br>
<br>
<br>

#### MainScene
|기능|기능 설명|스크립트|메서드|
|:---:|:---|:---:|:---:|
|플래너 팝업 열기|원하는 게임을 선택할 수 있는 플래너 팝업을 연다.|PlannerClickEvent.cs|[Update()](https://github.com/phw97123/PLANORPAIN/blob/f13925cf701b6cb917696f02047601c248281a25/Assets/Scripts/UI/Scene/MainScene/PlannerClickEvent.cs#L9)|
|게임 선택(1)|원하는 게임의 아이콘을 드래그 & 드롭할 수 있다.|[PlannerGameIcon.cs](https://github.com/phw97123/PLANORPAIN/blob/f13925cf701b6cb917696f02047601c248281a25/Assets/Scripts/UI/Planner/PlannerGameIcon.cs#L7)||
|게임 선택(2)|원하는 게임을 드래그 한 후, start 버튼을 누르면 해당 게임의 씬을 로드한다.|[PlannerGameSlot.cs](https://github.com/phw97123/PLANORPAIN/blob/f13925cf701b6cb917696f02047601c248281a25/Assets/Scripts/UI/Planner/PlannerGameSlot.cs#L10)|[OnClickStartButton()](https://github.com/phw97123/PLANORPAIN/blob/f13925cf701b6cb917696f02047601c248281a25/Assets/Scripts/UI/Planner/PlannerGameSlot.cs#L55)|
|게임 선택(3)|UI_planner 팝업에서 플레이한 게임과 결과, 플레이할 수 있는 게임의 아이콘을 표시한다.|[UI_Planner.cs](https://github.com/phw97123/PLANORPAIN/blob/f13925cf701b6cb917696f02047601c248281a25/Assets/Scripts/UI/Planner/UI_Planner.cs#L9)||
