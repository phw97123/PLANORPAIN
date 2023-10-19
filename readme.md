

### 미니게임 외 씬
#### StartScene
|기능|기능 설명|스크립트|메서드|
|:---:|:---:|:---:|:---:|
|게임 인트로 씬|관련된 BGM sound 재생 및 Playable Director 재생, Intro MainGameScene으로 진입할 수 있는 버튼을 표시한다.|[StartScene.cs](https://github.com/phw97123/PLANORPAIN/blob/f13925cf701b6cb917696f02047601c248281a25/Assets/Scripts/Scene/StartScene.cs#L7-L15)|Init()|

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

#### EndingScene

<br>

* 진행한 미니게임의 점수(별)을 합산해, 별에 개수에 맞는 Ending Playable Director을 보여줌.

* GoodEnding과 BadEnding 2가지 엔딩이 존재

<br>

|기능|기능 설명|스크립트|메서드|
|:---:|:---|:---:|:---:|
|씬 스크립트|UI와 EndingSceneController를 가져와 씬을 시작한다.|[EndingScene.cs](https://github.com/phw97123/PLANORPAIN/blob/91c32455c0e882c34a7b0bd4a65af0614edfca9d/Assets/Scripts/Scene/EndingScene.cs#L1)||
|엔딩 씬 결정|미니게임에서 얻은 점수를 기준으로 BadEnding, GoodEnding을 정하고, 맞는 Playable Director을 재생한다.|[EndingSceneController.cs](https://github.com/phw97123/PLANORPAIN/blob/d2d6de46338e9d2a2665a3be7e698ec0d883c94a/Assets/Scripts/Scene/EndingSceneController.cs#L6)||

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
|고양이 움직임 구현|고양이는 NavMesh를 활용하여 Object가 배치되지 않은 임의의 그리드를 이동한다.<br>목표지점 주변 이동 후에 새로운 목표지점을 정해 이동한다.|Cat.cs|[RandomNavMeshPosition()](https://github.com/phw97123/PLANORPAIN/blob/486c63f97853214c986c047aaa90a0f74c05cb1c/Assets/Scripts/Character/Cat/Cat.cs#L31)<br>[SetRandomDestination()](https://github.com/phw97123/PLANORPAIN/blob/486c63f97853214c986c047aaa90a0f74c05cb1c/Assets/Scripts/Character/Cat/Cat.cs#L24)|

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
|손님 상태 적용|손님의 상태를 AIState에 따라 정의하여, 관련된 변수를 초기화한다.|NPCConvenienceStore.cs|[SetState()](https://github.com/phw97123/PLANORPAIN/blob/0b22f4916b6a37531b3a5e322b109759cd3bba2c/Assets/Scripts/Character/NPCConvenienceStore/NPCConvenienceStore.cs#L51C18-L51C44)|
|인게임 UI|현재 점수의 상태를 별 모양 이미지로 나타내는 UI를 적용한다.|[ConvenienceUI.cs](https://github.com/phw97123/PLANORPAIN/blob/0b22f4916b6a37531b3a5e322b109759cd3bba2c/Assets/Scripts/UI/ConvenienceStoreScene/ConvenienceUI.cs#L7)||
|현재 점수 표시|현재 점수를 별 모양 이미지의 개수로 표시한다.|ConvenienceUI.cs|[ChangeStarImage()](https://github.com/phw97123/PLANORPAIN/blob/0b22f4916b6a37531b3a5e322b109759cd3bba2c/Assets/Scripts/UI/ConvenienceStoreScene/ConvenienceUI.cs#L18)|


<br>
<br>


#### GymGame

<br>

* 자동차를 타고 운전하여 gym에 도착하는 DriveScene과 gym 에서 운동하는 미니게임을 포함한 gymScene 이상의 2가지 씬으로 구성되어있다.

#### 1. DriveScene
|기능|기능 설명|스크립트|메서드|
|:---:|:---|:---:|:---:|
|씬 스크립트|UI와 게임의 매니저를 가져와 씬을 시작한다.|[DrivingScene.cs](https://github.com/phw97123/PLANORPAIN/blob/a78b21f9eed1517319b7a7a88ae51b152bc11943/Assets/Scripts/Scene/DrivingScene.cs#L6)||
|미니게임 매니저|게임 로직과 Popup UI를 관리한다.|[OutdoorGameManager.cs](https://github.com/phw97123/PLANORPAIN/blob/a78b21f9eed1517319b7a7a88ae51b152bc11943/Assets/Scripts/OutdoorGame/OutdoorGameManager.cs#L5)||
|상호작용 인터페이스|상호작용 가능한 오브젝트를 관리하는 스크립트에 부착하기 위해 제작한 인터페이스|[IInteractable.cs](https://github.com/phw97123/PLANORPAIN/blob/a78b21f9eed1517319b7a7a88ae51b152bc11943/Assets/Scripts/OutdoorGame/Interface/IInteractable.cs#L1)||
|자동차 운전|자동차를 방향키로 운전하는 것을 구현한다.|[VehicleController.cs](https://github.com/phw97123/PLANORPAIN/blob/a78b21f9eed1517319b7a7a88ae51b152bc11943/Assets/Scripts/OutdoorGame/Vehicle/VehicleController.cs#L7)||
|자동차 이동 구현(1)|지정한 InputSystem에서 전해주는 방향벡터를 토대로 자동차 이동을 구현한다.|VehicleController.cs|[OnDriveInput()](https://github.com/phw97123/PLANORPAIN/blob/a78b21f9eed1517319b7a7a88ae51b152bc11943/Assets/Scripts/OutdoorGame/Vehicle/VehicleController.cs#L82)|
|자동차 이동 구현(2)|자동차 바퀴들과 Wheel Collider들 각 4개의 transform.position을 동일하게 맞추고, Wheel Collider로 움직임과 방향을 조정한다.|VehicleController.cs|[Move()](https://github.com/phw97123/PLANORPAIN/blob/a78b21f9eed1517319b7a7a88ae51b152bc11943/Assets/Scripts/OutdoorGame/Vehicle/VehicleController.cs#L49)|
|자동차 위치 조정|자동차가 뒤집혔을 때, 처음의 위치로 자동차를 다시 구현한다.|VehicleController.cs|[OnRespawn()](https://github.com/phw97123/PLANORPAIN/blob/a78b21f9eed1517319b7a7a88ae51b152bc11943/Assets/Scripts/OutdoorGame/Vehicle/VehicleController.cs#L102C17-L102C26)|
|gym 이동|화면에서 지정한 Interact Point 에서, 지정한 버튼을 눌렀을 때, gymScene으로 이동할 수 있음을 보여주는 UI를 표시한다.|[InteractGymPoint.cs](https://github.com/phw97123/PLANORPAIN/blob/255cf515581694d3b87f8771bf5544f5e98cb8e7/Assets/Scripts/OutdoorGame/Interact/InteractGymPoint.cs#L5)||
|gym 이동(2)|지정한 버튼을 눌렀을 때, 1초 뒤에 gymScene을 로드한다.|InteractGymPoint.cs|[LoadSceneCO()](https://github.com/phw97123/PLANORPAIN/blob/fbd513b01adc83150c54b2543b14014e162244b4/Assets/Scripts/OutdoorGame/Interact/InteractGymPoint.cs#L39)|

#### 2. GymScene
|기능|기능 설명|스크립트|메서드|
|:---:|:---|:---:|:---:|
|씬 스크립트|UI와 게임의 매니저를 가져와 씬을 시작한다.|[GymScene.cs](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/Scene/GymScene.cs#L3)||
|오브젝트 접촉|오브젝트와 접촉하여 특정 미니게임 UI를 불러온다.|[InteractGymMinigame.cs](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/OutdoorGame/Interact/InteractGymMinigame.cs#L4)||
|오브젝트 표시 (1)|미니게임 UI와 연결된 오브젝트를 주황색 outline으로 강조한다.|[Outline.cs](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Externals/QuickOutline/Scripts/Outline.cs#L16)||
|오브젝트 표시 (2)|미니게임 UI와 연결된 오브젝트를 주황색 outline으로 강조하고, outline의 크기를 변화시킨다.|InteractGymMinigame.cs|[BlinkOutlingCO](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/OutdoorGame/Interact/InteractGymMinigame.cs#L22)|
|오브젝트 상호작용|미니게임 UI와 연결된 오브젝트와 상호작용하여 미니게임을 시작한다.|InteractGymMinigame.cs|[OnCollisionStay()](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/OutdoorGame/Interact/InteractGymMinigame.cs#L31)|
|러닝머신 미니게임 UI|러닝머신 미니게임을 관리 및 진행하는 UI.<br> 성공여부, 실패여부, 남은 시간, 요구 횟수 등을 표시한다.|[TreadmilMiniGameUI.cs](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/UI/GymScene/TreadmilMiniGameUI.cs#L8)||
|힛 바 적용(1)|미니게임의 힛 바를 space로 고정했을 때, 실패 혹은 성공여부를 판단한다.|TreadmilMiniGameUI.cs|[OnHitBar()](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/UI/GymScene/TreadmilMiniGameUI.cs#L114C17-L114C25)|
|힛 바 적용(2)|미니게임의 힛 바 움직임을 구현한다.|TreadmilMiniGameUI.cs|[DropBarImageChangeCO()](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/UI/GymScene/TreadmilMiniGameUI.cs#L235)|
|성공, 실패 적용|게임의 진행에 따라 성공과 실패했을 때의 상황을 구현한다.|TreadmilMiniGameUI.cs|[SuccessHitCO()](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/UI/GymScene/TreadmilMiniGameUI.cs#L131)<br>[FailHitCO()](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/UI/GymScene/TreadmilMiniGameUI.cs#L170C17-L170C28)|
|스쿼트 미니게임 UI|백스쿼트 미니게임을 관리 및 진행하는 UI.<br> 성공여부, 실패여부, 남은 시간, 요구 횟수 등을 표시한다.|[BackSquatMiniGameUI.cs](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/UI/GymScene/BackSquatMiniGameUI.cs#L8C14-L8C34)||
|현재 점수 반영 UI|화면 우측 상단에 해야할 일을 마칠 때마다, 별 이미지의 개수로써 현재 점수를 표시한다.|[StarUI.cs](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/UI/GymScene/StarUI.cs#L3)||
|출입구 표시|모든 미니게임을 마친 후, 나가는 문을 강조한다.<br>나가는 문과 상호작용 시, 게임이 끝나고, End Popup을 표시한다.|[InteractGymToOutPoint.cs](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/OutdoorGame/Interact/InteractGymToOutPoint.cs#L3)||


<br>
<br>
