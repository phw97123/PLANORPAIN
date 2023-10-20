![header](https://capsule-render.vercel.app/api?type=waving&color=EDCDBB&height=300&section=header&text=PLAN%20OR%20PAIN&fontSize=90&fontColor=FFEDDB)

## 목차

| [📅 프로젝트 미리 보기 📅](#프로젝트-미리-보기) |
| :---: |
| [🎬 Scene 설명서 🎬](#scene-설명서) |
| [🎨 UI 구성 🎨](#ui-구성) |
| [🛠 Manager 구조 🛠](#manager-구조) |
| [📜 Player 로직 📜](#player-로직) |
| [💡 만든 사람들 💡](#만든-사람들) |

<br>

* * *

<br>

## [🎮 YouTube]()
## [🤍 Team Notion](https://teamsparta.notion.site/B6-eaf3a5d7a8cd48b68f7ea83ec72f7e9e)

<br>

* * *

<br>

## 프로젝트 미리 보기

[📌 목차로 돌아가기 📌](#목차)

![슬라이드1](https://github.com/phw97123/PLANORPAIN/assets/62470991/deb7c0c1-8c51-46b7-aebd-0a303c8fc0e4)
![슬라이드2](https://github.com/phw97123/PLANORPAIN/assets/62470991/d19cec4f-065e-48b1-b561-a958c8c1dd0c)
![슬라이드3](https://github.com/phw97123/PLANORPAIN/assets/62470991/5b188a9f-efd5-45de-b017-4c334011021d)
![슬라이드4](https://github.com/phw97123/PLANORPAIN/assets/62470991/8b2dca5f-58c7-483e-a64c-370c855c7244)
![슬라이드5](https://github.com/phw97123/PLANORPAIN/assets/62470991/16a49ba4-a2c3-41e7-8843-638931d3ffb4)
![슬라이드6](https://github.com/phw97123/PLANORPAIN/assets/62470991/0fa9090c-eaba-42ce-8238-c2d149969d5d)
![슬라이드7](https://github.com/phw97123/PLANORPAIN/assets/62470991/ceb7f70e-9181-4380-8269-df0f92094d63)
![슬라이드8](https://github.com/phw97123/PLANORPAIN/assets/62470991/a0c9cda5-82eb-49bf-ad6c-cd8bc55250ec)
![슬라이드9](https://github.com/phw97123/PLANORPAIN/assets/62470991/ae637470-0648-4307-909e-7572fa9df0ed)
![슬라이드10](https://github.com/phw97123/PLANORPAIN/assets/62470991/27d0d74f-5c47-45e2-aaec-8bd439b201a6)
![슬라이드11](https://github.com/phw97123/PLANORPAIN/assets/62470991/f845af58-79e4-4186-9900-c7097fae78d3)
![슬라이드12](https://github.com/phw97123/PLANORPAIN/assets/62470991/0f43e987-da27-460d-82d6-735ca873a51f)
![슬라이드14](https://github.com/phw97123/PLANORPAIN/assets/62470991/a0d52cf2-8be1-4887-a231-2a6d5da0ec20)
![슬라이드15](https://github.com/phw97123/PLANORPAIN/assets/62470991/166d95cd-b55b-4acb-9fc8-64a002fd308f)
![슬라이드16](https://github.com/phw97123/PLANORPAIN/assets/62470991/0c713a70-1d37-431f-91dd-b7b4a089982f)
![슬라이드17](https://github.com/phw97123/PLANORPAIN/assets/62470991/23b32cd6-984a-4aec-a16a-55e3db1a0f52)
![슬라이드18](https://github.com/phw97123/PLANORPAIN/assets/62470991/691f4edb-b0a3-4611-b954-272757f67bfb)
![슬라이드19](https://github.com/phw97123/PLANORPAIN/assets/62470991/ee6f3766-6034-4bf9-b2b9-830e661f0dd3)

<br>

* * *

<br>

## Scene 설명서

<br>

[📌 목차로 돌아가기 📌](#목차)

<br>

#### Scene 설명서 목차

| [🍿 주요 Scene 🍿](#주요-scene) |
| :---: |
| [🥤 미니 게임 Scene 🥤](#미니-게임-scene) |

<br>

* * *

<br>

### 주요 Scene

<br>

[🎥 Scene 설명서 목차로 돌아가기 🎥](#scene-설명서-목차)

<br>

| [🐈 StartScene 🐈](#startscene) |
| :---: |
| [🏠 MainScene 🏠](#mainscene) |
| [🛌 EndingScene 🛌](#endingscene) |

<br>

#### StartScene
|기능|기능 설명|스크립트|메서드|
|:---:|:---:|:---:|:---:|
|게임 인트로 씬|관련된 BGM sound 재생 및 Playable Director 재생, Intro MainGameScene으로 진입할 수 있는 버튼을 표시한다.|[StartScene.cs](https://github.com/phw97123/PLANORPAIN/blob/f13925cf701b6cb917696f02047601c248281a25/Assets/Scripts/Scene/StartScene.cs#L7-L15)|Init()|

<br><br>

#### MainScene
|기능|기능 설명|스크립트|메서드|
|:---:|:---|:---:|:---:|
|플래너 팝업 열기|원하는 게임을 선택할 수 있는 플래너 팝업을 연다.|PlannerClickEvent.cs|[Update()](https://github.com/phw97123/PLANORPAIN/blob/f13925cf701b6cb917696f02047601c248281a25/Assets/Scripts/UI/Scene/MainScene/PlannerClickEvent.cs#L9)|
|게임 선택(1)|원하는 게임의 아이콘을 드래그 & 드롭할 수 있다.|[PlannerGameIcon.cs](https://github.com/phw97123/PLANORPAIN/blob/f13925cf701b6cb917696f02047601c248281a25/Assets/Scripts/UI/Planner/PlannerGameIcon.cs#L7)||
|게임 선택(2)|원하는 게임을 드래그 한 후, start 버튼을 누르면 해당 게임의 씬을 로드한다.|[PlannerGameSlot.cs](https://github.com/phw97123/PLANORPAIN/blob/f13925cf701b6cb917696f02047601c248281a25/Assets/Scripts/UI/Planner/PlannerGameSlot.cs#L10)|[OnClickStartButton()](https://github.com/phw97123/PLANORPAIN/blob/f13925cf701b6cb917696f02047601c248281a25/Assets/Scripts/UI/Planner/PlannerGameSlot.cs#L55)|
|게임 선택(3)|UI_planner 팝업에서 플레이한 게임과 결과, 플레이할 수 있는 게임의 아이콘을 표시한다.|[UI_Planner.cs](https://github.com/phw97123/PLANORPAIN/blob/f13925cf701b6cb917696f02047601c248281a25/Assets/Scripts/UI/Planner/UI_Planner.cs#L9)||

<br><br>

#### EndingScene

* 진행한 미니게임의 점수(별)을 합산해, 별에 개수에 맞는 Ending Playable Director을 보여줌.

* GoodEnding과 BadEnding 2가지 엔딩이 존재

<br>

|기능|기능 설명|스크립트|메서드|
|:---:|:---|:---:|:---:|
|씬 스크립트|UI와 EndingSceneController를 가져와 씬을 시작한다.|[EndingScene.cs](https://github.com/phw97123/PLANORPAIN/blob/91c32455c0e882c34a7b0bd4a65af0614edfca9d/Assets/Scripts/Scene/EndingScene.cs#L1)||
|엔딩 씬 결정|미니게임에서 얻은 점수를 기준으로 BadEnding, GoodEnding을 정하고, 맞는 Playable Director을 재생한다.|[EndingSceneController.cs](https://github.com/phw97123/PLANORPAIN/blob/d2d6de46338e9d2a2665a3be7e698ec0d883c94a/Assets/Scripts/Scene/EndingSceneController.cs#L6)||

<br>

* * *

<br>

### 미니 게임 Scene

<br>

[🎥 Scene 설명서 목차로 돌아가기 🎥](#scene-설명서-목차)

<br>

#### 미니 게임 Scene 목차

| [🐾 집안일 하기 게임 🐾](#집안일-하기-게임) |
| :---: |
| [🍙 알바하기 게임 🍙](#알바하기-게임) |
| [🌵 개발하기 게임 🌵](#개발하기-게임) |
| [🌋 게임하기 게임 🌋](#게임하기-게임) |
| [👟 외출하기 게임 👟](#외출하기-게임) |

<br><br>

#### 집안일 하기 게임

<br>

[🎮 미니 게임 Scene 목차로 돌아가기 🎮](#미니-게임-scene-목차)

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
|고양이 구현|시간이 30초 남았을 때, 플레이어가 청소한 타일을 방해하는 고양이를 구현한다.|[Cat.cs](https://github.com/phw97123/PLANORPAIN/blob/fedb8d0b27f8c3fc22113b649f987d68872caf0a/Assets/Scripts/Character/Cat/Cat.cs)||
|고양이 움직임 구현|고양이는 NavMesh를 활용하여 Object가 배치되지 않은 임의의 그리드를 이동한다.<br>목표지점 주변 이동 후에 새로운 목표지점을 정해 이동한다.|Cat.cs|[RandomNavMeshPosition()](https://github.com/phw97123/PLANORPAIN/blob/486c63f97853214c986c047aaa90a0f74c05cb1c/Assets/Scripts/Character/Cat/Cat.cs#L31)<br>[SetRandomDestination()](https://github.com/phw97123/PLANORPAIN/blob/486c63f97853214c986c047aaa90a0f74c05cb1c/Assets/Scripts/Character/Cat/Cat.cs#L24)|

<br><br>

#### 알바하기 게임

<br>

[🎮 미니 게임 Scene 목차로 돌아가기 🎮](#미니-게임-scene-목차)

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

<br><br>

#### 개발하기 게임

<br>

[🎮 미니 게임 Scene 목차로 돌아가기 🎮](#미니-게임-scene-목차)

<br>

* 주어진 Node 탐색을 맵에 있는 Node들을 알맞은 순서로 활성화시켜야 하는 게임.

|기능|기능 설명|스크립트|메서드|
|:---:|:---|:---:|:---:|
|씬 스크립트|UI와 게임의 매니저를 가져와 씬을 시작한다.|[DevelopGameScene.cs](https://github.com/phw97123/PLANORPAIN/blob/9936e17209c6cf32565e543ffad1709fecbfced7/Assets/Scripts/Scene/DevelopGameScene.cs#L5)||
|미니게임 매니저|게임 로직과 Popup UI를 관리한다.|[DevelopGameManager.cs](https://github.com/phw97123/PLANORPAIN/blob/9936e17209c6cf32565e543ffad1709fecbfced7/Assets/Scripts/DevelopGame/DevelopGameManager.cs#L7)||
|시도 횟수 카운트|맵에 있는 Node를 알맞은 순서로 모두 활성화시킬 때까지 시도한 횟수를 카운트한다.|DevelopGameManager.cs|[UpdateTryCount()](https://github.com/phw97123/PLANORPAIN/blob/9936e17209c6cf32565e543ffad1709fecbfced7/Assets/Scripts/DevelopGame/DevelopGameManager.cs#L52C17-L52C31)|
|리스폰|맵의 특정 고도 이하로 떨어질 경우, 처음 시작 위치로 플레이어를 강제 이동한다.|DevelopGameManager.cs|[Respawn()](https://github.com/phw97123/PLANORPAIN/blob/9936e17209c6cf32565e543ffad1709fecbfced7/Assets/Scripts/DevelopGame/DevelopGameManager.cs#L45C17-L45C24)|
|노드 관리|캐릭터가 활성화시키는 노드의 순서를 체크한다.|[Graph.cs](https://github.com/phw97123/PLANORPAIN/blob/9936e17209c6cf32565e543ffad1709fecbfced7/Assets/Scripts/DevelopGame/Graph.cs#L6)||
|노드 표시|캐릭터가 노드 주변에 있을 떄, (노드 주변에 노드보다 큰 투명한 collider 설정) 플레이어에게 해당 노드를 활성화 시킬 지 선택하게 하는 팝업을 표시한다.|Node.cs||
|충돌 감지|플레이어가 노드 주변에 있을 때를 감지한다.|Node.cs|[OnTriggerEnter()](https://github.com/phw97123/PLANORPAIN/blob/9936e17209c6cf32565e543ffad1709fecbfced7/Assets/Scripts/DevelopGame/Node.cs#L32C18-L32C32)|

<br><br>

#### 게임하기 게임

<br>

[🎮 미니 게임 Scene 목차로 돌아가기 🎮](#미니-게임-scene-목차)

<br>

* 주어진 시간 안에, 흔들리는 지형 속에서 최대한 용암에 닿지 않고 살아남아야 하는 게임.

<br>

|기능|기능 설명|스크립트|메서드|
|:---:|:---|:---:|:---:|
|씬 스크립트|UI와 게임의 매니저를 가져와 씬을 시작한다.|[DodgeGameScene.cs](https://github.com/phw97123/PLANORPAIN/blob/19c67a7168b8b5d97ea49534fa909cdc662f7644/Assets/Scripts/Scene/DodgeGameScene.cs#L1)||
|미니게임 매니저|게임 로직과 Popup UI를 관리한다.|[DodgeGameManager.cs](https://github.com/phw97123/PLANORPAIN/blob/19c67a7168b8b5d97ea49534fa909cdc662f7644/Assets/Scripts/DodgeMiniGame/DodgeGameManager.cs#L4)||
|용암 접촉시 소리 재생|용암 접촉시, 지속적으로 소리를 재생한다.|DodgeGameManager.cs|[PlayLavaSound()](https://github.com/phw97123/PLANORPAIN/blob/19c67a7168b8b5d97ea49534fa909cdc662f7644/Assets/Scripts/DodgeMiniGame/DodgeGameManager.cs#L72)|
|인게임 UI|남은 HP, 남은 시간, 획득한 점수를 반영하는 인게임 UI를 구현한다.|[UI_DodgeGameScene.cs](https://github.com/phw97123/PLANORPAIN/blob/3e4f40de77a65d299d706b0b0f0f8930d5db4082/Assets/Scripts/UI/Scene/DodgeGameScene/UI_DodgeGameScene.cs#L5)||
|그라운드 관리|여러 개의 그라운드 조각들을 리스트로 관리하여, 지정한 시간마다 그라운드 조각을 ShiverState로 전환한다.|[GroundManager.cs](https://github.com/phw97123/PLANORPAIN/blob/3e4f40de77a65d299d706b0b0f0f8930d5db4082/Assets/Scripts/Ground/GroundManager.cs#L6)||
|그라운드 관리 (1)|지정한 시간마다 임의의 조각을 ShiverState로 전환한다.|GroundManager.cs|[ShiverGround()](https://github.com/phw97123/PLANORPAIN/blob/3e4f40de77a65d299d706b0b0f0f8930d5db4082/Assets/Scripts/Ground/GroundManager.cs#L62)|
|그라운드 관리 (2)|지정한 시간마다 플레이어가 서 있는 그라운드 조각을 ShiverState로 전환한다.|GroundManger.cs|[CheckPlayerOnGround()](https://github.com/phw97123/PLANORPAIN/blob/3e4f40de77a65d299d706b0b0f0f8930d5db4082/Assets/Scripts/Ground/GroundManager.cs#L82)|
|그라운드|땅에 대한 정보와 State 전환을 관리한다.|[Ground.cs](https://github.com/phw97123/PLANORPAIN/blob/3e4f40de77a65d299d706b0b0f0f8930d5db4082/Assets/Scripts/Ground/Ground.cs#L4)||
|그라운드 파괴|FallState로 전환한 땅의 transform.position.y 가 지정한 위치에 도달했을 때, 오브젝트를 파괴한다.|Ground.cs|[OnDestroyObject](https://github.com/phw97123/PLANORPAIN/blob/3e4f40de77a65d299d706b0b0f0f8930d5db4082/Assets/Scripts/Ground/Ground.cs#L46)|
|그라운드 상태 전환|ShiverState로 전환한 땅을 지정한 시간 뒤에 FallState로 전환시킨다.|Ground.cs|[ChangeToFallState](https://github.com/phw97123/PLANORPAIN/blob/3e4f40de77a65d299d706b0b0f0f8930d5db4082/Assets/Scripts/Ground/Ground.cs#L51C17-L51C34)|

<br><br>

#### 외출하기 게임

<br>

[🎮 미니 게임 Scene 목차로 돌아가기 🎮](#미니-게임-scene-목차)

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

<br>

#### 2. GymScene
|기능|기능 설명|스크립트|메서드|
|:---:|:---|:---:|:---:|
|씬 스크립트|UI와 게임의 매니저를 가져와 씬을 시작한다.|[GymScene.cs](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/Scene/GymScene.cs#L3)||
|인 게임 UI|미니게임과 gym 필드에서 플레이어, 상호작용, 위치 조정등을 구현하는 UI|[GymMiniGameUI.cs](https://github.com/phw97123/PLANORPAIN/blob/85a7fed1b083efd2f4dd6cd3ecf5622911f6768c/Assets/Scripts/UI/GymScene/GymMiniGameUI.cs#L5)||
|플레이어 상호작용|플레이어와 충돌한 물체를 확인 후, 관련된 미니게임을 시작한다.|GymMiniGameUI.cs|[OnInteract()](https://github.com/phw97123/PLANORPAIN/blob/85a7fed1b083efd2f4dd6cd3ecf5622911f6768c/Assets/Scripts/UI/GymScene/GymMiniGameUI.cs#L43)|
|미니게임 상호작용|미니게임에서 Space 버튼의 상호작용을 구현한다.|GymMiniGameUI.cs|[OnSpace()](https://github.com/phw97123/PLANORPAIN/blob/85a7fed1b083efd2f4dd6cd3ecf5622911f6768c/Assets/Scripts/UI/GymScene/GymMiniGameUI.cs#L70)|
|플레이어 리스폰|플레이어가 최초 생성한 자리에서 재생성된다.|GymMiniGameUI.cs|[OnRespawn()](https://github.com/phw97123/PLANORPAIN/blob/85a7fed1b083efd2f4dd6cd3ecf5622911f6768c/Assets/Scripts/UI/GymScene/GymMiniGameUI.cs#L86)|
|출입구 활성화|모든 미니게임이 진행되었는 지 여부를 확인하고, 충족되었다면 출입구를 활성화한다.|GymMiniGameUI.cs|[UpdateDoorColliderCO()](https://github.com/phw97123/PLANORPAIN/blob/85a7fed1b083efd2f4dd6cd3ecf5622911f6768c/Assets/Scripts/UI/GymScene/GymMiniGameUI.cs#L28)|
|오브젝트 접촉|오브젝트와 접촉하여 특정 미니게임 UI를 불러온다.|[InteractGymMinigame.cs](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/OutdoorGame/Interact/InteractGymMinigame.cs#L4)||
|오브젝트 표시 (1)|미니게임 UI와 연결된 오브젝트를 주황색 outline으로 강조한다.|[Outline.cs](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Externals/QuickOutline/Scripts/Outline.cs#L16)||
|오브젝트 표시 (2)|미니게임 UI와 연결된 오브젝트를 주황색 outline으로 강조하고, outline의 크기를 변화시킨다.|InteractGymMinigame.cs|[BlinkOutlingCO](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/OutdoorGame/Interact/InteractGymMinigame.cs#L22)|
|오브젝트 상호작용|미니게임 UI와 연결된 오브젝트와 상호작용하여 GymMiniGameUI 에 자신의 정보를 전달한다.|InteractGymMinigame.cs|[OnCollisionStay()](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/OutdoorGame/Interact/InteractGymMinigame.cs#L31)|
|러닝머신 미니게임 UI|러닝머신 미니게임을 관리 및 진행하는 UI.<br> 성공여부, 실패여부, 남은 시간, 요구 횟수 등을 표시한다.|[TreadmilMiniGameUI.cs](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/UI/GymScene/TreadmilMiniGameUI.cs#L8)||
|힛 바 적용(1)|미니게임의 힛 바를 space로 고정했을 때, 실패 혹은 성공여부를 판단한다.|TreadmilMiniGameUI.cs|[OnHitBar()](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/UI/GymScene/TreadmilMiniGameUI.cs#L114C17-L114C25)|
|힛 바 적용(2)|미니게임의 힛 바 움직임을 구현한다.|TreadmilMiniGameUI.cs|[DropBarImageChangeCO()](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/UI/GymScene/TreadmilMiniGameUI.cs#L235)|
|성공, 실패 적용|게임의 진행에 따라 성공과 실패했을 때의 상황을 구현한다.|TreadmilMiniGameUI.cs|[SuccessHitCO()](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/UI/GymScene/TreadmilMiniGameUI.cs#L131)<br>[FailHitCO()](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/UI/GymScene/TreadmilMiniGameUI.cs#L170C17-L170C28)|
|스쿼트 미니게임 UI|백스쿼트 미니게임을 관리 및 진행하는 UI.<br> 성공여부, 실패여부, 남은 시간, 요구 횟수 등을 표시한다.|[BackSquatMiniGameUI.cs](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/UI/GymScene/BackSquatMiniGameUI.cs#L8C14-L8C34)||
|현재 점수 반영 UI|화면 우측 상단에 해야할 일을 마칠 때마다, 별 이미지의 개수로써 현재 점수를 표시한다.|[StarUI.cs](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/UI/GymScene/StarUI.cs#L3)||
|출입구 표시|모든 미니게임을 마친 후, 나가는 문을 강조한다.<br>나가는 문과 상호작용 시, 게임이 끝나고, End Popup을 표시한다.|[InteractGymToOutPoint.cs](https://github.com/phw97123/PLANORPAIN/blob/4e25fb5662896defaa3cb6869ba108aa117b3e34/Assets/Scripts/OutdoorGame/Interact/InteractGymToOutPoint.cs#L3)||

<br>

* * *

<br>

## UI 구성

<br>

[📌 목차로 돌아가기 📌](#목차)

<br>

### UIBase

* 모든 UI는 UI_base를 상속받음.
* 모든 팝업을 상속하는 UI_basePopup 또한 UI_base를 상속받음.

|메서드|기능 설명|
|:---:|:---|
|[OpenUI()](https://github.com/phw97123/PLANORPAIN/blob/7d8ed77c3582719f8f42a16d4c546da6ec900a23/Assets/Scripts/UI/Parent/UIBase.cs#L5)|연결된 게임오브젝트(UI)를 활성화|
|[CloseUI()](https://github.com/phw97123/PLANORPAIN/blob/7d8ed77c3582719f8f42a16d4c546da6ec900a23/Assets/Scripts/UI/Parent/UIBase.cs#L10)|연결된 게임오브젝트(UI)를 비활성화|

<br><br>

### Scene UI

* 각 씬별로 필요한 정보 (ex. 남은 시간, 현재 점수 ... etc)를 메서드로 구현한다.
* 각 씬별 UI는 상단의 "씬 별 설명" 의 인게임 UI 항목 참고 혹은 하단 표 참고.

|씬|UI|
|:---:|:---:|
|StartScene|[UI_StartScene.cs](https://github.com/phw97123/PLANORPAIN/blob/3b0c67266bb23924d410f3549811b2336bfdf7de/Assets/Scripts/UI/Scene/UI_StartScene.cs#L4)|
|MainScene|[UI_MainScene.cs](https://github.com/phw97123/PLANORPAIN/blob/3b0c67266bb23924d410f3549811b2336bfdf7de/Assets/Scripts/UI/Scene/UI_MainScene.cs#L5)|
|CleaningGameScene|[CleaningGameSceneUI.cs](https://github.com/phw97123/PLANORPAIN/blob/fedb8d0b27f8c3fc22113b649f987d68872caf0a/Assets/Scripts/UI/Scene/CleaningGameScene/CleaningGameSceneUI.cs#L8)|
|DevelopGameScene|[UI_DevelopGameScene.cs](https://github.com/phw97123/PLANORPAIN/blob/3b0c67266bb23924d410f3549811b2336bfdf7de/Assets/Scripts/UI/Scene/UI_DevelopGameScene.cs#L5)|
|ConvenienceGameScene|[ConvenienceUI.cs](https://github.com/phw97123/PLANORPAIN/blob/0b22f4916b6a37531b3a5e322b109759cd3bba2c/Assets/Scripts/UI/ConvenienceStoreScene/ConvenienceUI.cs#L7)|
|DodgeGameScene|[UI_DodgeGameScene](https://github.com/phw97123/PLANORPAIN/blob/3b0c67266bb23924d410f3549811b2336bfdf7de/Assets/Scripts/UI/Scene/DodgeGameScene/UI_DodgeGameScene.cs#L5)|

<br><br>

### UI_BasePopup

* 모든 팝업은 UI_BasePopup을 상속받음.
* UI_BasePopup은 다음의 필드값을 지니고 있음.

```c#
public class UI_BasePopup : UIBase
{
    [SerializeField] protected Image _popupBackgroundImage;
    [SerializeField] protected GameObject _contentTextObject;

    protected TMP_Text _contentText;

    protected virtual void Awake()
    {
        _contentText = _contentTextObject.GetComponent<TMP_Text>();
        CloseUI();
    }
    //... 생략 ...

```

|메서드|기능 설명|
|:---:|:---|
|[SetPopupAttributesSize()](https://github.com/phw97123/PLANORPAIN/blob/7d8ed77c3582719f8f42a16d4c546da6ec900a23/Assets/Scripts/UI/UIPopup/UI_BasePopup.cs#L19)|팝업의 크기 및 텍스트 위치 조절|
|[SetPopupContent()](https://github.com/phw97123/PLANORPAIN/blob/7d8ed77c3582719f8f42a16d4c546da6ec900a23/Assets/Scripts/UI/UIPopup/UI_BasePopup.cs#L27C20-L27C35)|팝업 내용 텍스트 및 폰트 사이즈 조절|

<br><br>

### UI_Popup

* 인 게임 내에서 자주 쓰이는 팝업 정의.
* content 텍스트 및 버튼 오브젝트들을 GameObject로 저굥한 뒤, InitBind 함수 내에서 해당하는 Button과 TMP_Text를 연결.
* [const values region](https://github.com/phw97123/PLANORPAIN/blob/fc1edf865e426636bb174a974233540577e46e2f/Assets/Scripts/UI/UIPopup/UI_Popup.cs#L15) 에서 팝업 사이즈와 관련된 상수 정의
* [Global/Strings](https://github.com/phw97123/PLANORPAIN/blob/2be575db0da474bf3578cc580cbb7d1031412e2e/Assets/Scripts/Global/Strings.cs#L9) 에서 정의한 버튼 타입에 따른 텍스트를 부여한다.

```c#
public class UI_Popup : UI_BasePopup
{
   //... 생략 ...
    public delegate void Callback();
    private Callback callbackConfirm;
    private Callback callbackCancel;
    private Callback callbackOk;

    [SerializeField] private GameObject _confirmButtonObject;
    [SerializeField] private GameObject _cancelButtonObject;
    [SerializeField] private GameObject _okButtonObject;

    private Button _confirmButton;
    private Button _cancelButton;
    private Button _okButton;

    private TMP_Text _confirmButtonText;
    private TMP_Text _cancelButtonText;
    private TMP_Text _okButtonText;

    protected override void Awake()
    {
        InitBind();
        base.Awake();
    }
    //... 생략 ...

```

|기능|메서드|기능 설명|
|:---:|:---:|:---|
|데이터 연결|[InitBind()](https://github.com/phw97123/PLANORPAIN/blob/fc1edf865e426636bb174a974233540577e46e2f/Assets/Scripts/UI/UIPopup/UI_Popup.cs#L58)|연결된 버튼과 TMP_text, 버튼의 이벤트를 연결한다.|
|데이터 연결|[SetButtonActive()](https://github.com/phw97123/PLANORPAIN/blob/fc1edf865e426636bb174a974233540577e46e2f/Assets/Scripts/UI/UIPopup/UI_Popup.cs#L74)|지정한 버튼 타입에 따라, 알맞은 게임오브젝트(버튼)를 활성화 혹은 비활성화시킨다.|
|팝업 표시(1)|[ShowPopup()](https://github.com/phw97123/PLANORPAIN/blob/fc1edf865e426636bb174a974233540577e46e2f/Assets/Scripts/UI/UIPopup/UI_Popup.cs#L99)|파라미터로 입력받은 버튼의 콜백마다 알맞은 버튼을 연결한다.<br>Confirm 버튼, Cancel 버튼이 있는 팝업 (= cancel 콜백, confirm 콜백을 파라미터로 받음)|
|팝업 표시(2)|[ShowPopup()](https://github.com/phw97123/PLANORPAIN/blob/fc1edf865e426636bb174a974233540577e46e2f/Assets/Scripts/UI/UIPopup/UI_Popup.cs#L115)|파라미터로 입력받은 버튼의 콜백마다 알맞은 버튼을 연결한다.<br>OK 버튼이 있는 팝업(= OK 콜백을 파라미터로 받음)|
|팝업 표시(3)|[ShowPopup()](https://github.com/phw97123/PLANORPAIN/blob/fc1edf865e426636bb174a974233540577e46e2f/Assets/Scripts/UI/UIPopup/UI_Popup.cs#L128)|파라미터로 입력받은 버튼의 콜백마다 알맞은 버튼을 연결한다.<br>버튼이 없는 알림 팝업|
|팝업 닫기|[ClosePopup()](https://github.com/phw97123/PLANORPAIN/blob/fc1edf865e426636bb174a974233540577e46e2f/Assets/Scripts/UI/UIPopup/UI_Popup.cs#L140)|버튼을 클릭할 시, 각 버튼에 연결되어 있는 콜백 메서드를 실행하고, 열려있는 팝업을 닫는다.|
|팝업 지연 닫기|[CloseUIWithDelay()](https://github.com/phw97123/PLANORPAIN/blob/fc1edf865e426636bb174a974233540577e46e2f/Assets/Scripts/UI/UIPopup/UI_Popup.cs#L149)|1초 뒤에 UI를 닫는다.|
|팝업 크기 및 텍스트 위치 조절|[SetPopupAttributes](https://github.com/phw97123/PLANORPAIN/blob/fc1edf865e426636bb174a974233540577e46e2f/Assets/Scripts/UI/UIPopup/UI_Popup.cs#L156)|파라미터로 받는 팝업 버튼의 종류에 따라, 버튼 크기와 텍스트 위치를 지정한다.|

<br>

* * *

<br>

## Manager 구조

<br>

[📌 목차로 돌아가기 📌](#목차)

<br>

### [SceneManagerEx](https://github.com/phw97123/PLANORPAIN/blob/4bf0791cfcbed240d2324f3f3d05ffdccf9334b3/Assets/Scripts/Manager/SceneManagerEx.cs#L4C14-L4C29)

* 현재 씬과 다음 씬을 토대로, 씬 전환을 관리한다.
* [Global/Scenes.cs](https://github.com/phw97123/PLANORPAIN/blob/4bf0791cfcbed240d2324f3f3d05ffdccf9334b3/Assets/Scripts/Global/Scenes.cs#L1) 에서 씬 타입을 정의하고, 정의한 씬을 호출한다.

|필드값|기능 설명|
|:---:|:---|
|_curSceneType|현재 씬|
|_nextSceneType|현재 씬이 LoadingScene일 경우 다음에 호출 될 씬|

<br><br>

### [GameManager](https://github.com/phw97123/PLANORPAIN/blob/98a33ae535c8fb95d9a486ea815b17bae9e04288/Assets/Scripts/Manager/GameManager.cs#L7)

* 각 미니 게임들을 관리하는 미니 게임 매니저들을 Dictionary로 관리한다.
* 각 미니 게임의 플레이 여부와 엔딩 여부를 관리한다.
* 각 미니 게임간 Scene을 로드한다.

|필드값|기능 설명|
|:---:|:---|
|CurDay|현재 요일을 결정한다.|
|GameSceneDB|모든 씬의 이름을 요소로 가지고 있는 배열.|
|CurGame|현재 플레이하고 있는 씬.|
|RemainingGames|아직 플레이 하지 않은 미니게임 씬을 key 값, 해당 미니게임의 아이콘 이미지 스프라이트의 이름을 value 값으로 가지고 있는 딕셔너리.|
|UsingGames|플레이한 미니게임 씬을 key 값, 해당 미니게임의 아이콘 이미지 스프라이트의 이름을 value 값으로 가지고 있는 딕셔너리.|
|GameStars|플레이 결과 (3점 만점) 에서 각 1점씩을 요소(1점 혹은 0점)로 하는 리스트.|
|CurStar|가장 최근에 플레이한 미니게임의 플레이 결과를 나타낸 int.|
|IsGoodEnding|GoodEnding 여부를 판단하는 bool.|
|gameEnd|모든 미니게임을 플레이해 엔딩씬으로 넘어가는지 여부를 판단하는 bool.|
|_gameIconPath|각 미니게임의 아이콘 이미지 스프라이트의 이름을 요소로 가진 배열|

<br><br>

### [UIManager](https://github.com/phw97123/PLANORPAIN/blob/fd6ccb92c452dc317de6cca4b0cb815ba18ebea5/Assets/Scripts/Manager/UIManager.cs#L5)

* 특정 UI 컴포넌트를 지닌 프리팹의 경로를 key값으로, UI 컴포넌트를 value값으로 하는 딕셔너리를 통해 UI 컴포넌트를 관리한다.
* 지정한 경로에서의 프리팹을 Instantiate 한 후, UI 컴포넌트를 가져온다.

<br><br>

### [ResourceManager](https://github.com/phw97123/PLANORPAIN/blob/4bf0791cfcbed240d2324f3f3d05ffdccf9334b3/Assets/Scripts/Manager/ResourceManager.cs#L4)

* 이미지 소스의 경로를 key값으로 이미지 소스 Sprite을 value값으로 하는 딕셔너리를 통해, 리소스를 관리한다.

<br><br>

### [SoundManager](https://github.com/phw97123/PLANORPAIN/blob/ca12f4fb5f7bbce6535165bad8a4e81b5b972860/Assets/Scripts/Manager/SoundManager.cs#L10)

* 사운드 소스의 경로를 key값으로, 사운드 clip을 value 값으로 하는 딕셔너리를 통해, 사운드를 관리한다.
* [AudioType](https://github.com/phw97123/PLANORPAIN/blob/ca12f4fb5f7bbce6535165bad8a4e81b5b972860/Assets/Scripts/Manager/SoundManager.cs#L4) 으로 지정한 오디오 클립의 타입에 따라 다른 방식으로 지정한 audioSource를 재생할 수 있다.
* audioSource에 상관없이 플레이 중인 사운드를 정지할 수 있다.

<br><br>

<br>

* * *

<br>

## Player 로직

<br>

[📌 목차로 돌아가기 📌](#목차)

<br>

### New Input System 활용.

![image](https://github.com/phw97123/PLANORPAIN/assets/141595995/580d5c85-5c4b-47ef-8408-d22b894b1d20)

* 지정한 버튼이 눌린다면, 눌린 형태 (Performed, Canceled, started) 까지 이벤트에 대한 콜백 함수로 사용하요 지정한 동작 수행.

* 각 게임 별로 동일한 플레이어를 사용하고 있고, 게임마다 필요한 Input System 이 다른 것은, 필요한 모든 이벤트를 저장한 후, 씬 별로 선택적으로 액션을 적용하여 구현함.

```c#
// Player.cs

    public void EnableActions(params InputActions[] actionNames)
    {
        Input.OnDisable(); 
        foreach (InputActions actionName in actionNames)
        {
            InputAction action = Input.InputActions.FindAction(actionName.ToString());
            if (action != null)
                action.Enable();
            else
                Debug.LogError($"{action} 는 존재하지 않습니다."); 
        }
    }
```

<br><br>

### FSM 활용

![image](https://github.com/phw97123/PLANORPAIN/assets/141595995/797db143-13c2-44cf-8888-da2710edffa8)

* FSM 을 활용하여, 플레이어의 각 State를 정의하고, State 별 전환 조건을 충족시킬 때마다, State를 전환시킴.
* State 별 전환 및 정보를 관리하는 [PlayerStateMachine.cs](https://github.com/phw97123/PLANORPAIN/blob/1b917e6e680dfec71a4def9ba1e69c1268d531a9/Assets/Scripts/Character/Player/StateMachines/PlayerStateMachine.cs#L3) 과 애니메이션 해시 정보를 관리하는 [PlayerAnimationData.cs](https://github.com/phw97123/PLANORPAIN/blob/1b917e6e680dfec71a4def9ba1e69c1268d531a9/Assets/Scripts/Character/Player/PlayerAnimationData.cs#L5) 를 통해 각 State 별 필요한 물리적 움직임과 애니메이션(애니메이터 파라미터 조절)을 불러옴.

<br>

* * *

<br>

## 만든 사람들

[⭐ 목차로 돌아가기 ⭐](#목차)

<a href="https://github.com/phw97123/PLANORPAIN/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=phw97123/PLANORPAIN" />
  </a>

<br><br>
