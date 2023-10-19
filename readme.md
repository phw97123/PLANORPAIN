


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
|씬 스크립트|UI와 게임의 매니저를 가져와 씬을 시작한다.|[CleaningGameScene.cs](https://github.com/phw97123/PLANORPAIN/blob/fedb8d0b27f8c3fc22113b649f987d68872caf0a/Assets/Scripts/Scene/CleaningGameScene.cs#L5)||
|미니게임 매니저|게임 로직과 Popup UI를 관리한다.|[CleaningGameManager.cs](https://github.com/phw97123/PLANORPAIN/blob/fedb8d0b27f8c3fc22113b649f987d68872caf0a/Assets/Scripts/CleaningGame/CleaningGameManager.cs#L13)||
|인게임 UI|남은 시간과 획득한 점수를 표시한다.|[CleaningGameSceneUI.cs](https://github.com/phw97123/PLANORPAIN/blob/fedb8d0b27f8c3fc22113b649f987d68872caf0a/Assets/Scripts/UI/Scene/CleaningGameScene/CleaningGameSceneUI.cs#L8)||
|바닥 그리드화|플레이어가 활동할 수 있는 지역을 그리드로 만든다.|[PlaceObjectOnGrid.cs](https://github.com/phw97123/PLANORPAIN/blob/9936e17209c6cf32565e543ffad1709fecbfced7/Assets/Scripts/CleaningGame/PlaceObjectOnGrid.cs#L7)||
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
|씬 스크립트|UI와 게임의 매니저를 가져와 씬을 시작한다.|[DevelopGameScene.cs](https://github.com/phw97123/PLANORPAIN/blob/9936e17209c6cf32565e543ffad1709fecbfced7/Assets/Scripts/Scene/DevelopGameScene.cs#L5)||
|미니게임 매니저|게임 로직과 Popup UI를 관리한다.|[DevelopGameManager.cs](https://github.com/phw97123/PLANORPAIN/blob/9936e17209c6cf32565e543ffad1709fecbfced7/Assets/Scripts/DevelopGame/DevelopGameManager.cs#L7)||
|시도 횟수 카운트|맵에 있는 Node를 알맞은 순서로 모두 활성화시킬 때까지 시도한 횟수를 카운트한다.|DevelopGameManager.cs|[UpdateTryCount()](https://github.com/phw97123/PLANORPAIN/blob/9936e17209c6cf32565e543ffad1709fecbfced7/Assets/Scripts/DevelopGame/DevelopGameManager.cs#L52C17-L52C31)|
|리스폰|맵의 특정 고도 이하로 떨어질 경우, 처음 시작 위치로 플레이어를 강제 이동한다.|DevelopGameManager.cs|[Respawn()](https://github.com/phw97123/PLANORPAIN/blob/9936e17209c6cf32565e543ffad1709fecbfced7/Assets/Scripts/DevelopGame/DevelopGameManager.cs#L45C17-L45C24)|
|노드 관리|캐릭터가 활성화시키는 노드의 순서를 체크한다.|[graph.cs](https://github.com/phw97123/PLANORPAIN/blob/9936e17209c6cf32565e543ffad1709fecbfced7/Assets/Scripts/DevelopGame/Graph.cs#L6)||
|노드 표시|캐릭터가 노드 주변에 있을 떄, (노드 주변에 노드보다 큰 투명한 collider 설정) 플레이어에게 해당 노드를 활성화 시킬 지 선택하게 하는 팝업을 표시한다.|Node.cs||
|충돌 감지|플레이어가 노드 주변에 있을 때를 감지한다.|Node.cs|[OnTriggerEnter()](https://github.com/phw97123/PLANORPAIN/blob/9936e17209c6cf32565e543ffad1709fecbfced7/Assets/Scripts/DevelopGame/Node.cs#L32C18-L32C32)|

<br>
<br>

#### ConvenienceStoreScene

<br>

* 아르바이트를 하던 중, 문득 배가 고파졌다. 점장의 CCTV 감시와, 손님이 눈치채지 못하게 몰래 삼각김밥을 섭취해야하는 게임.

*  점장의 CCTV 감시는 화면상 왼쪽 아래 모니터로 알 수 있다.

*  손님은 또한 눈치챌 수 있는 범위를 지니고 있는데, 이 범위 밖에 있을 때만 삼각김밥을 섭취해야한다.

<br>

|기능|기능 설명|스크립트|메서드|
|:---:|:---|:---:|:---:|
|씬 스크립트|UI와 게임의 매니저를 가져와 씬을 시작한다.|[ConvenienceStoreScene.cs](https://github.com/phw97123/PLANORPAIN/blob/96057e87d3aebbd939d28d3ec374be5cc21a35ec/Assets/Scripts/Scene/ConvenienceStoreScene.cs#L5)||
|미니게임 매니저|게임 로직과 Popup UI를 관리한다.|[ConvenienceStoreGameManager.cs](https://github.com/phw97123/PLANORPAIN/blob/96057e87d3aebbd939d28d3ec374be5cc21a35ec/Assets/Scripts/ConvenienceStoreGame/ConvenienceStoreGameManager.cs#L7)||
|삼각김밥 섭취|삼각김밥을 클릭해서 섭취하고 있을 때, 다른 오브젝트들의 정보를 불러와 상황에 맞는 결과를 불러온다.|ConvenienceStoreGameManager.cs|[CheckClickRiceBall()](https://github.com/phw97123/PLANORPAIN/blob/96057e87d3aebbd939d28d3ec374be5cc21a35ec/Assets/Scripts/ConvenienceStoreGame/ConvenienceStoreGameManager.cs#L77)|
|삼각김밥 모양 반영|게임 진행 상태를 삼각김밥의 모양으로 표시한다.|ConvenienceStoreGameManager.cs|[ChangeRiceBallModel()](https://github.com/phw97123/PLANORPAIN/blob/96057e87d3aebbd939d28d3ec374be5cc21a35ec/Assets/Scripts/ConvenienceStoreGame/ConvenienceStoreGameManager.cs#L138C18-L138C37)|
|점수 반영|지정한 조건을 충족할 때마다, 점수를 감점시킨다.|ConvenienceStoreGameManager.cs|[ChangeScore()](https://github.com/phw97123/PLANORPAIN/blob/96057e87d3aebbd939d28d3ec374be5cc21a35ec/Assets/Scripts/ConvenienceStoreGame/ConvenienceStoreGameManager.cs#L126)|
|게임 방법 안내|게임 방법에 대해 설명하는 팝업을 표시한다.|[ConvenienceNotifyUI.cs](https://github.com/phw97123/PLANORPAIN/blob/0b22f4916b6a37531b3a5e322b109759cd3bba2c/Assets/Scripts/UI/ConvenienceStoreScene/ConvenienceNotifyUI.cs#L7C42-L7C42)||
|손님 움직임 정의|손님의 움직임을 FSM으로 구현한다. 손님은 Idle, Wandering State를 가진다.|[NPCConvenienceStore.cs](https://github.com/phw97123/PLANORPAIN/blob/0b22f4916b6a37531b3a5e322b109759cd3bba2c/Assets/Scripts/Character/NPCConvenienceStore/NPCConvenienceStore.cs#L12C14-L12C33)||
|손님 상태 적용|손님의 상태를 AIState에 따라 정의하여, 관련된 변수를 초기화한다.|NPCConvenienceStore.cs|[SetState(AIState newState)](https://github.com/phw97123/PLANORPAIN/blob/0b22f4916b6a37531b3a5e322b109759cd3bba2c/Assets/Scripts/Character/NPCConvenienceStore/NPCConvenienceStore.cs#L51C18-L51C44)|
|인게임 UI|현재 점수의 상태를 별 모양 이미지로 나타내는 UI를 적용한다.|[ConvenienceUI.cs](https://github.com/phw97123/PLANORPAIN/blob/0b22f4916b6a37531b3a5e322b109759cd3bba2c/Assets/Scripts/UI/ConvenienceStoreScene/ConvenienceUI.cs#L7)||
|현재 점수 표시|현재 점수를 별 모양 이미지의 개수로 표시한다.|ConvenienceUI.cs|[ChangeStarImage()](https://github.com/phw97123/PLANORPAIN/blob/0b22f4916b6a37531b3a5e322b109759cd3bba2c/Assets/Scripts/UI/ConvenienceStoreScene/ConvenienceUI.cs#L18)|


<br>
<br>



