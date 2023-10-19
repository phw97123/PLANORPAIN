using UnityEngine;
using UnityEngine.UI;

public class UI_Planner : UIBase
{
    [SerializeField] private Image[] grayMasks; //꼭 월~금 순서대로 넣기
    [SerializeField] private Image[] sticker;
    [SerializeField] private RectTransform backGround;
    [SerializeField] private RectTransform gameIconPosition;
    [SerializeField] private Button EndingButton;
    private GameManager _gameManager;
    private RectTransform[] _gameIcons;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        EndingButton.onClick.AddListener(GameManager.Instance.LoadEndingScene);
    }

    private void OnEnable()
    {
        PlannerUIUpdate();
    }

    private void PlannerUIUpdate()
    {
        ChangeAlphaGrayMask();

        LoadGameSlots();

        LoadGameIcons();

        if (_gameManager.gameEnd) EndingButton.gameObject.SetActive(true);
    }

    private void ChangeAlphaGrayMask()
    {
        Color newColor = Color.white;
        newColor.a = 0;
        for (int i = 0; i <= (int)_gameManager.CurDay; i++)
        {
            grayMasks[i].color = newColor;
        }
    }

    private void LoadGameSlots() //리팩토링하기
    {

        Image curDayMask = grayMasks[(int)_gameManager.CurDay];
        GameObject curSlot = Instantiate(Resources.Load<GameObject>($"Prefabs/UI/Planner/PlannerGameSlot"));
        curSlot.transform.SetParent(backGround.transform);
        curSlot.GetComponent<RectTransform>().anchoredPosition = curDayMask.GetComponent<RectTransform>().anchoredPosition;

        int dayIndex = 0;
        foreach (var gamePair in _gameManager.UsingGames)
        {
            curDayMask = grayMasks[dayIndex];
            curSlot = Instantiate(Resources.Load<GameObject>($"Prefabs/UI/Planner/PlannerGameSlot"));
            curSlot.transform.SetParent(backGround.transform);
            curSlot.GetComponent<RectTransform>().anchoredPosition = curDayMask.GetComponent<RectTransform>().anchoredPosition;

            PlannerGameSlot slot = curSlot.GetComponent<PlannerGameSlot>();
            slot.GameImage.sprite = ResourceManager.Instance.LoadSprite($"{gamePair.Value}_thumbnail");
            slot.IsDestoryed = false;
            slot.enabled = false;

            sticker[dayIndex].sprite = ResourceManager.Instance.LoadSprite($"{gamePair.Value}_sticker");
            sticker[dayIndex].gameObject.SetActive(true); 

            for (int i = 0; i < 3; i++)
            {
                slot.StarImage[i].gameObject.SetActive(true);
                if (i < _gameManager.GameStars[dayIndex]) slot.StarImage[i].sprite = ResourceManager.Instance.LoadSprite("Planner/filledStar");
            }

            dayIndex++;
        }
    }

    private void LoadGameIcons()
    {
        if (_gameIcons != null)
        {
            foreach (var iconrect in _gameIcons)
            {
                Destroy(iconrect.gameObject);
            }
        }
        _gameIcons = new RectTransform[_gameManager.RemainingGames.Count];
        int index = 0;
        foreach (var gamePair in _gameManager.RemainingGames)
        {
            _gameIcons[index] = Instantiate(Resources.Load<GameObject>($"Prefabs/UI/Planner/PlannerGameIcon")).GetComponent<RectTransform>();
            _gameIcons[index].transform.SetParent(backGround.transform);
            PlannerGameIcon plannerGameIcon = _gameIcons[index].gameObject.GetComponent<PlannerGameIcon>();
            plannerGameIcon.GameIcon.sprite = ResourceManager.Instance.LoadSprite(gamePair.Value);
            plannerGameIcon.GameScene = gamePair.Key;
            plannerGameIcon.StartPosition = gameIconPosition.anchoredPosition + new Vector2(1.4f * index * (_gameIcons[index].sizeDelta.x), 0);
            plannerGameIcon.GoStartPosition();
            index++;
        }
    }
}
